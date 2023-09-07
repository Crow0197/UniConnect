using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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

        public GruppoController(UserManager<ApplicationUser> userManager, IOptionsMonitor<JwtConfig> optionsMonitor, IMapper mapper, RoleManager<IdentityRole> roleMgr, IRepository<Gruppo> repository)
        {
            _roleManager = roleMgr;
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
            _mapper = mapper;
            _repository = repository;
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

        // POST api/Gruppo
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Gruppo gruppo)
        {
            if (gruppo == null)
            {
                return BadRequest(); // Restituisci una risposta HTTP 400 Bad Request se il gruppo è nullo
            }

            await _repository.AddAsync(gruppo); // Inserisci il nuovo gruppo nel repository in modo asincrono
            return CreatedAtAction(nameof(Get), new { id = gruppo.GroupId }, gruppo); // Restituisci una risposta HTTP 201 Created con il nuovo gruppo
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
