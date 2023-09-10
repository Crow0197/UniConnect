using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models;
using Repo.Ef;
using Repo.Ef.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniConnect.BLL.Service; // Assicurati di importare il namespace corretto per il tuo servizio

namespace UniConnect.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private RoleManager<IdentityRole> _roleManager;
        private readonly EventoService _eventoService; // Usa il servizio EventoService invece del repository

        public EventoController(UserManager<ApplicationUser> userManager, IMapper mapper, RoleManager<IdentityRole> roleMgr, EventoService eventoService)
        {
            _roleManager = roleMgr;
            _userManager = userManager;
            _mapper = mapper;
            _eventoService = eventoService; // Inietta il servizio EventoService
        }

        // GET: api/Evento

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var eventi = await _eventoService.GetEventiAsync(); // Usa il servizio per ottenere gli eventi
            return Ok(eventi);
        }

        [HttpGet("eventi/{userId}")]
        public async Task<IActionResult> GetEventi(string userId)
        {
            var response = await _eventoService.GetEventiAsync(userId);
            if (response.EventiAssociati.Any() || response.EventiCreati.Any() || response.AltriEventi.Any())
            {
                return Ok(response);
            }
            return NotFound();
        }



        // GET api/Evento/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var evento = await _eventoService.GetEventoByIdAsync(id); // Usa il servizio per ottenere un evento per ID

            if (evento == null)
            {
                return NotFound();
            }

            return Ok(evento);
        }

        // POST api/Evento
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EventoRequest evento)
        {
            if (evento == null)
            {
                return BadRequest();
            }

            var success = await _eventoService.CreateEventoAsync(evento); // Usa il servizio per creare un evento

            return Ok();
        }

        // PUT api/Evento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EventoRequest updatedEvento)
        {
            if (updatedEvento == null || id != updatedEvento.EventId)
            {
                return BadRequest();
            }

            var success = await _eventoService.UpdateEventoAsync(id, updatedEvento); // Usa il servizio per aggiornare un evento

            if (success)
            {
                return NoContent();
            }
            else
            {
                return NotFound(); // Cambiare questo comportamento in base alle esigenze
            }
        }

        // DELETE api/Evento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _eventoService.DeleteEventoAsync(id); // Usa il servizio per eliminare un evento

            if (success)
            {
                return NoContent();
            }
            else
            {
                return NotFound(); // Cambiare questo comportamento in base alle esigenze
            }
        }
    }
}
