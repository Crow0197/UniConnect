using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Repo.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuelsTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly GdrcontextContext _context;


        public RoleController(RoleManager<IdentityRole> roleMgr, UserManager<ApplicationUser> userManager, GdrcontextContext context)
        {
            roleManager = roleMgr;
            _context = context;
            _userManager = userManager;

        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {

            var AdminRole = new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "Admin"


            };
            await roleManager.CreateAsync(AdminRole);

            var UserRole = new IdentityRole
            {
                Name = "User",
                NormalizedName = "User"


            };
            await roleManager.CreateAsync(UserRole);


            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("AssignRoleToUser")]
        public async Task<IActionResult> AssignRoleToUser(string _email)
        {
            //Created a user
            // assign an existing role to the newly created user

            //List<string> roles = roleManager.Roles.Select(x => x.Name).ToList();

            var user = await _userManager.FindByEmailAsync(_email);



            await  _userManager.AddToRoleAsync(user, "Admin");

            return RedirectToAction("Index");
        }


    }
}
