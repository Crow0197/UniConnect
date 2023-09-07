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
    public class PostController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtConfig _jwtConfig;
        private readonly IMapper _mapper;
        private RoleManager<IdentityRole> _roleManager;
        private readonly IRepository<Post> _repository;

        public PostController(UserManager<ApplicationUser> userManager, IOptionsMonitor<JwtConfig> optionsMonitor, IMapper mapper, RoleManager<IdentityRole> roleMgr, IRepository<Post> repository)
        {
            _roleManager = roleMgr;
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
            _mapper = mapper;
            _repository = repository;
        }

        // GET: api/Post
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await _repository.GetAllAsync(); // Recupera tutti i post dal repository in modo asincrono
            return Ok(posts); // Restituisci una risposta HTTP 200 OK con i post
        }

        // GET api/Post/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var post = await _repository.GetByIdAsync(id); // Recupera il post per l'ID specificato dal repository in modo asincrono

            if (post == null)
            {
                return NotFound(); // Restituisci una risposta HTTP 404 Not Found se il post non esiste
            }

            return Ok(post); // Restituisci una risposta HTTP 200 OK con il post
        }

        // POST api/Post
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Post post)
        {
            if (post == null)
            {
                return BadRequest(); // Restituisci una risposta HTTP 400 Bad Request se il post è nullo
            }

            await _repository.AddAsync(post); // Inserisci il nuovo post nel repository in modo asincrono
            return CreatedAtAction(nameof(Get), new { id = post.PostId }, post); // Restituisci una risposta HTTP 201 Created con il nuovo post
        }

        // PUT api/Post/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Post updatedPost)
        {
            if (updatedPost == null || id != updatedPost.PostId)
            {
                return BadRequest(); // Restituisci una risposta HTTP 400 Bad Request se il post è nullo o l'ID non corrisponde
            }

            var existingPost = await _repository.GetByIdAsync(id);

            if (existingPost == null)
            {
                return NotFound(); // Restituisci una risposta HTTP 404 Not Found se il post non esiste
            }

            existingPost.Content = updatedPost.Content;
            existingPost.Timestamp = updatedPost.Timestamp;

            await _repository.UpdateAsync(existingPost); // Aggiorna il post esistente nel repository in modo asincrono
            return NoContent(); // Restituisci una risposta HTTP 204 No Content
        }

        // DELETE api/Post/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var post = await _repository.GetByIdAsync(id);

            if (post == null)
            {
                return NotFound(); // Restituisci una risposta HTTP 404 Not Found se il post non esiste
            }

            await _repository.DeleteAsync(id); // Elimina il post dal repository in modo asincrono
            return NoContent(); // Restituisci una risposta HTTP 204 No Content
        }
    }
}
