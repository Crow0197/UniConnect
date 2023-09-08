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
using UniConnect.BLL;

namespace UniConnect.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentoController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtConfig _jwtConfig;
        private readonly IMapper _mapper;
        private RoleManager<IdentityRole> _roleManager;
        private readonly IRepository<Commento> _repository;

        public CommentoController(UserManager<ApplicationUser> userManager, IOptionsMonitor<JwtConfig> optionsMonitor, IMapper mapper, RoleManager<IdentityRole> roleMgr, IRepository<Commento> repository)
        {
            _roleManager = roleMgr;
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
            _mapper = mapper;
            _repository = repository;
        }

        // GET: api/Commento
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var commenti = await _repository.GetAllAsync(); // Recupera tutti i commenti dal repository in modo asincrono
            return Ok(commenti); // Restituisci una risposta HTTP 200 OK con i commenti
        }

        // GET api/Commento/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var commento = await _repository.GetByIdAsync(id); // Recupera il commento per l'ID specificato dal repository in modo asincrono

            if (commento == null)
            {
                return NotFound(); // Restituisci una risposta HTTP 404 Not Found se il commento non esiste
            }

            return Ok(commento); // Restituisci una risposta HTTP 200 OK con il commento
        }

        // POST api/Commento
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CommentoRequest commento)
        {
            if (commento == null)
            {
                return BadRequest(); // Restituisci una risposta HTTP 400 Bad Request se il commento è nullo
            }

            var commentoDb = _mapper.Map<Commento>(commento);
            await _repository.AddAsync(commentoDb); // Inserisci il nuovo commento nel repository in modo asincrono
            return Ok();
        }

        // PUT api/Commento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Commento updatedCommento)
        {
            if (updatedCommento == null || id != updatedCommento.CommentId)
            {
                return BadRequest(); // Restituisci una risposta HTTP 400 Bad Request se il commento è nullo o l'ID non corrisponde
            }

            var existingCommento = await _repository.GetByIdAsync(id);

            if (existingCommento == null)
            {
                return NotFound(); // Restituisci una risposta HTTP 404 Not Found se il commento non esiste
            }

            existingCommento.Content = updatedCommento.Content;
            existingCommento.Timestamp = updatedCommento.Timestamp;

            await _repository.UpdateAsync(existingCommento); // Aggiorna il commento esistente nel repository in modo asincrono
            return NoContent(); // Restituisci una risposta HTTP 204 No Content
        }

        // DELETE api/Commento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var commento = await _repository.GetByIdAsync(id);

            if (commento == null)
            {
                return NotFound(); // Restituisci una risposta HTTP 404 Not Found se il commento non esiste
            }

            await _repository.DeleteAsync(id); // Elimina il commento dal repository in modo asincrono
            return NoContent(); // Restituisci una risposta HTTP 204 No Content
        }
    }
}
