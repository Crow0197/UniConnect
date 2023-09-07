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
    public class FileStorageController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtConfig _jwtConfig;
        private readonly IMapper _mapper;
        private RoleManager<IdentityRole> _roleManager;
        private readonly IRepository<FileStorage> _repository;

        public FileStorageController(UserManager<ApplicationUser> userManager, IOptionsMonitor<JwtConfig> optionsMonitor, IMapper mapper, RoleManager<IdentityRole> roleMgr, IRepository<FileStorage> repository)
        {
            _roleManager = roleMgr;
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
            _mapper = mapper;
            _repository = repository;
        }

        // GET: api/FileStorage
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var files = await _repository.GetAllAsync(); // Recupera tutti i file dal repository in modo asincrono
            return Ok(files); // Restituisci una risposta HTTP 200 OK con i file
        }

        // GET api/FileStorage/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var file = await _repository.GetByIdAsync(id); // Recupera il file per l'ID specificato dal repository in modo asincrono

            if (file == null)
            {
                return NotFound(); // Restituisci una risposta HTTP 404 Not Found se il file non esiste
            }

            return Ok(file); // Restituisci una risposta HTTP 200 OK con il file
        }

        // POST api/FileStorage
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FileStorage file)
        {
            if (file == null)
            {
                return BadRequest(); // Restituisci una risposta HTTP 400 Bad Request se il file è nullo
            }

            await _repository.AddAsync(file); // Inserisci il nuovo file nel repository in modo asincrono
            return CreatedAtAction(nameof(Get), new { id = file.FileId }, file); // Restituisci una risposta HTTP 201 Created con il nuovo file
        }

        // PUT api/FileStorage/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FileStorage updatedFile)
        {
            if (updatedFile == null || id != updatedFile.FileId)
            {
                return BadRequest(); // Restituisci una risposta HTTP 400 Bad Request se il file è nullo o l'ID non corrisponde
            }

            var existingFile = await _repository.GetByIdAsync(id);

            if (existingFile == null)
            {
                return NotFound(); // Restituisci una risposta HTTP 404 Not Found se il file non esiste
            }

            existingFile.FileName = updatedFile.FileName;
            existingFile.FilePath = updatedFile.FilePath;
            existingFile.FileType = updatedFile.FileType;

            await _repository.UpdateAsync(existingFile); // Aggiorna il file esistente nel repository in modo asincrono
            return NoContent(); // Restituisci una risposta HTTP 204 No Content
        }

        // DELETE api/FileStorage/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var file = await _repository.GetByIdAsync(id);

            if (file == null)
            {
                return NotFound(); // Restituisci una risposta HTTP 404 Not Found se il file non esiste
            }

            await _repository.DeleteAsync(id); // Elimina il file dal repository in modo asincrono
            return NoContent(); // Restituisci una risposta HTTP 204 No Content
        }
    }
}
