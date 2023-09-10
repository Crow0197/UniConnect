using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniConnect.BLL.Service;

namespace UniConnect.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentoController : ControllerBase
    {
        private readonly CommentoService _commentoService;

        public CommentoController(CommentoService commentoService)
        {
            _commentoService = commentoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int postId)
        {
            var commenti = await _commentoService.GetCommentiAsync(postId);
            return Ok(commenti);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CommentoRequest commento)
        {
            if (commento == null)
            {
                return BadRequest();
            }

            var success = await _commentoService.CreateCommentoAsync(commento);

            if (success)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CommentoRequest updatedCommento)
        {
            if (updatedCommento == null || id != updatedCommento.CommentId)
            {
                return BadRequest();
            }

            var success = await _commentoService.UpdateCommentoAsync(id, updatedCommento);

            if (success)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _commentoService.DeleteCommentoAsync(id);

            if (success)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
