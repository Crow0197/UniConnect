using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models;
using Models.Response;
using Repo.Ef;
using Repo.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniConnect.BLL;

namespace UniConnect.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GruppoController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtConfig _jwtConfig;
        private readonly IMapper _mapper;
        private RoleManager<IdentityRole> _roleManager;
        private readonly IRepository<Gruppo> _repository;
        private readonly IRepositoryGruppi _repositoryGruppi;


        public GruppoController(UserManager<ApplicationUser> userManager, IOptionsMonitor<JwtConfig> optionsMonitor, IMapper mapper, RoleManager<IdentityRole> roleMgr, IRepository<Gruppo> repository, IRepositoryGruppi repositoryGruppi)
        {
            _roleManager = roleMgr;
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
            _mapper = mapper;
            _repository = repository;
            _repositoryGruppi = repositoryGruppi;
        }

        // GET: api/Gruppo
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var gruppi = await _repository.GetAllAsync(); // Recupera tutti i gruppi dal repository in modo asincrono
            return Ok(gruppi); // Restituisci una risposta HTTP 200 OK con i gruppi
        }

        // GET api/Gruppo/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var gruppo = await _repository.GetByIdAsync(id); // Recupera il gruppo per l'ID specificato dal repository in modo asincrono

            if (gruppo == null)
            {
                return NotFound(); // Restituisci una risposta HTTP 404 Not Found se il gruppo non esiste
            }

            return Ok(gruppo); // Restituisci una risposta HTTP 200 OK con il gruppo
        }


        [HttpGet("gruppi/{userId}")]
        public async Task<IActionResult> GetGruppi(string userId)
        {
            var gruppiAssociati = await _repositoryGruppi.GetGruppiAssociatiAsync(userId);
            var gruppiCreati = await _repositoryGruppi.GetGruppiCreatiAsync(userId);
            var altriGruppi = await _repositoryGruppi.GetAltriGruppiAsync(userId);

            if (!gruppiAssociati.Any() && !gruppiCreati.Any() && !altriGruppi.Any())
            {
                return NotFound();
            }

            var response = new GruppiResponse
            {
                GruppiAssociati = _mapper.Map<List<GruppoResponse>>(gruppiAssociati),
                GruppiCreati = _mapper.Map<List<GruppoResponse>>(gruppiCreati),
                AltriGruppi = _mapper.Map<List<GruppoResponse>>(altriGruppi)
            };

            return Ok(response);
        }


        [HttpGet("gruppi-master-data/{userId}")]
        public async Task<IActionResult> GetGruppiMasterData(string userId)
        {
            var gruppiAssociati = await _repositoryGruppi.GetGruppiAssociatiAsync(userId);          
            if (!gruppiAssociati.Any() )
            {
                List<GruppoResponse> list = new List<GruppoResponse>();
                return Ok(list);
            }          
            return Ok(_mapper.Map<List<GruppoResponse>>(gruppiAssociati));
        }


        // POST api/Gruppo
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GruppoRequest gruppo)
        {
            if (gruppo == null)
            {
                return BadRequest(); // Restituisci una risposta HTTP 400 Bad Request se il gruppo è nullo
            }
            var gruppoDb = _mapper.Map<Gruppo>(gruppo);

            gruppoDb.UserId = gruppo.IdUser;
            var existingUser = await _userManager.FindByIdAsync(gruppo.IdUser);
            List<ApplicationUser> itemList = new List<ApplicationUser> { existingUser };

            gruppoDb.User = itemList;
            await _repository.AddAsync(gruppoDb ); // Inserisci il nuovo post nel repository in modo asincrono
            return Ok();
        }

        // PUT api/Gruppo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Gruppo updatedGruppo)
        {
            if (updatedGruppo == null || id != updatedGruppo.GroupId)
            {
                return BadRequest(); // Restituisci una risposta HTTP 400 Bad Request se il gruppo è nullo o l'ID non corrisponde
            }

            var existingGruppo = await _repository.GetByIdAsync(id);

            if (existingGruppo == null)
            {
                return NotFound(); // Restituisci una risposta HTTP 404 Not Found se il gruppo non esiste
            }

            existingGruppo.GroupName = updatedGruppo.GroupName;
            existingGruppo.Description = updatedGruppo.Description;
            existingGruppo.CreationDate = updatedGruppo.CreationDate;

            await _repository.UpdateAsync(existingGruppo); // Aggiorna il gruppo esistente nel repository in modo asincrono
            return NoContent(); // Restituisci una risposta HTTP 204 No Content
        }

        // DELETE api/Gruppo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var gruppo = await _repository.GetByIdAsync(id);

            if (gruppo == null)
            {
                return NotFound(); // Restituisci una risposta HTTP 404 Not Found se il gruppo non esiste
            }

            await _repository.DeleteAsync(id); // Elimina il gruppo dal repository in modo asincrono
            return NoContent(); // Restituisci una risposta HTTP 204 No Content
        }
    }
}
