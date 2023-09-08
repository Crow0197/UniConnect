using AutoMapper;
using UniConnect.BLL;
using UniConnect.Request;
using UniConnect.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repo.Ef;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace UniConnect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthManagementController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtConfig _jwtConfig;
        private readonly IMapper _mapper;
        private RoleManager<IdentityRole> _roleManager;
        private readonly IRepository<Pg> _repository;


        public AuthManagementController(UserManager<ApplicationUser> userManager, IOptionsMonitor<JwtConfig> optionsMonitor, IMapper mapper, RoleManager<IdentityRole> roleMgr, IRepository<Pg> repository)
        {
            _roleManager = roleMgr;
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
            _mapper = mapper;
            _repository = repository;
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest user)
        {
            if (ModelState.IsValid)
            {
                // check if the user with the same email exist
                var existingUser = await _userManager.FindByEmailAsync(user.Email);

                if (existingUser == null)
                {
                    // We dont want to give to much information on why the request has failed for security reasons
                    return Ok(new RegistrationResponse()
                    {
                        Result = false,
                        Errors = new List<string>(){
                                        "Invalid authentication request"
                                    }
                    });
                }

                // Now we need to check if the user has inputed the right password
                var isCorrect = await _userManager.CheckPasswordAsync(existingUser, user.Password);
                var roles = await _userManager.GetRolesAsync(existingUser);

                if (isCorrect)
                {
                    var jwtToken = GenerateJwtToken(existingUser, roles.ToList());

                    return Ok(new LoginResponse()
                    {
                        Result = true,
                        Token = jwtToken,
                        User = existingUser
                    });
                }
                else
                {
                    // We dont want to give to much information on why the request has failed for security reasons
                    return Ok(new LoginResponse()
                    {
                        Result = false,
                        Errors = new List<string>(){
                                         "Invalid authentication request"
                                    }
                    });
                }
            }

            return BadRequest(new RegistrationResponse()
            {
                Result = false,
                Errors = new List<string>(){
                                        "Invalid payload"
                                    }
            });
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequestDto user)
        {

            // Check if the incoming request is valid
            if (ModelState.IsValid)
            {
                // check i the user with the same email exist
                var existingUser = await _userManager.FindByEmailAsync(user.Email);

                if (existingUser != null)
                {
                    return BadRequest(new RegistrationResponse()
                    {
                        Result = false,
                        Errors = new List<string>(){
                                            "Email already exist"
                                        }
                    });
                }


                var newUser = new ApplicationUser() { Email = user.Email, UserName = user.Name, Avatar = user.Avatar };
                var isCreated = await _userManager.CreateAsync(newUser, user.Password);
                if (isCreated.Succeeded)
                {

                    _userManager.AddToRoleAsync(newUser, "User").GetAwaiter().GetResult();

                    List<string> roleNew = new List<string>() { "User" };
                    var jwtToken = GenerateJwtToken(newUser, roleNew);

                    return Ok(new RegistrationResponse()
                    {
                        Result = true,
                        Token = jwtToken,
                        User = newUser
                    });
                }

                return new JsonResult(new RegistrationResponse()
                {
                    Result = false,
                    Errors = isCreated.Errors.Select(x => x.Description).ToList()
                }
                        )
                { StatusCode = 500 };
            }

            return BadRequest(new RegistrationResponse()
            {
                Result = false,
                Errors = new List<string>(){
                                            "Invalid payload"
                                        }
            });
        }

        [HttpPost]
        [Route("Role")]
        public async Task<IActionResult> CreateRole()
        {

            var roleName = "User";

            var roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                var newRole = new IdentityRole { Name = roleName };
                var result = await _roleManager.CreateAsync(newRole);

                if (result.Succeeded)
                {
                    // Il ruolo è stato creato con successo.
                    return Ok();
                }
                else
                {
                    return Ok();
                }
            }
            else
            {
                return Ok();
            }
        }



        private string GenerateJwtToken(IdentityUser user, List<string> roles)
        {

            var claims = new[]
            {
                        new Claim(ClaimTypes.Name, user.UserName)
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ijurkbdlhmklqacwqzdxmkkhvqowlyqa"));

            var token = new JwtSecurityToken(
                issuer: "il_tuo_emittente",
                audience: "il_tuo_pubblico",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
    }
}
