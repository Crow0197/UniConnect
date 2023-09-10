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
    public class EventoController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtConfig _jwtConfig;
        private readonly IMapper _mapper;
        private RoleManager<IdentityRole> _roleManager;
        private readonly IRepository<Evento> _repository;

        public EventoController(UserManager<ApplicationUser> userManager, IOptionsMonitor<JwtConfig> optionsMonitor, IMapper mapper, RoleManager<IdentityRole> roleMgr, IRepository<Evento> repository)
        {
            _roleManager = roleMgr;
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
            _mapper = mapper;
            _repository = repository;
        }

        // GET: api/Evento
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var eventi = await _repository.GetAllAsync(); // Recupera tutti gli eventi dal repository in modo asincrono
            return Ok(eventi); // Restituisci una risposta HTTP 200 OK con gli eventi
        }

        // GET api/Evento/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var evento = await _repository.GetByIdAsync(id); // Recupera l'evento per l'ID specificato dal repository in modo asincrono

            if (evento == null)
            {
                return NotFound(); // Restituisci una risposta HTTP 404 Not Found se l'evento non esiste
            }

            return Ok(evento); // Restituisci una risposta HTTP 200 OK con l'evento
        }

        // POST api/Evento
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Evento evento)
        {
            if (evento == null)
            {
                return BadRequest(); // Restituisci una risposta HTTP 400 Bad Request se l'evento è nullo
            }

            await _repository.AddAsync(evento); // Inserisci il nuovo evento nel repository in modo asincrono
            return CreatedAtAction(nameof(Get), new { id = evento.EventId }, evento); // Restituisci una risposta HTTP 201 Created con il nuovo evento
        }

        // PUT api/Evento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Evento updatedEvento)
        {
            if (updatedEvento == null || id != updatedEvento.EventId)
            {
                return BadRequest(); // Restituisci una risposta HTTP 400 Bad Request se l'evento è nullo o l'ID non corrisponde
            }

            var existingEvento = await _repository.GetByIdAsync(id);

            if (existingEvento == null)
            {
                return NotFound(); // Restituisci una risposta HTTP 404 Not Found se l'evento non esiste
            }

            existingEvento.EventName = updatedEvento.EventName;
            existingEvento.Description = updatedEvento.Description;
            existingEvento.Date = updatedEvento.Date;
            existingEvento.Location = updatedEvento.Location;

            await _repository.UpdateAsync(existingEvento); // Aggiorna l'evento esistente nel repository in modo asincrono
            return NoContent(); // Restituisci una risposta HTTP 204 No Content
        }

        // DELETE api/Evento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var evento = await _repository.GetByIdAsync(id);

            if (evento == null)
            {
                return NotFound(); // Restituisci una risposta HTTP 404 Not Found se l'evento non esiste
            }

            await _repository.DeleteAsync(id); // Elimina l'evento dal repository in modo asincrono
            return NoContent(); // Restituisci una risposta HTTP 204 No Content
        }
    }
}
