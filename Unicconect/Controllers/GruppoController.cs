using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Linq;
using System.Threading.Tasks;
using UniConnect.BLL.Service;

namespace UniConnect.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GruppoController : ControllerBase
    {
        private readonly GruppoService _gruppoService;

        public GruppoController(GruppoService gruppoService)
        {
            _gruppoService = gruppoService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var gruppi = await _gruppoService.GetGruppiAsync();
            return Ok(gruppi);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var gruppo = await _gruppoService.GetGruppoByIdAsync(id);
            if (gruppo == null)
            {
                return NotFound();
            }
            return Ok(gruppo);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GruppoRequest gruppo)
        {
            var success = await _gruppoService.CreateGruppoAsync(gruppo);
            if (!success)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] GruppoRequest updatedGruppo)
        {
            var success = await _gruppoService.UpdateGruppoAsync(id, updatedGruppo);
            if (!success)
            {
                return BadRequest();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _gruppoService.DeleteGruppoAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("gruppi/{userId}")]
        public async Task<IActionResult> GetGruppi(string userId)
        {
            var response = await _gruppoService.GetGruppiAsync(userId);
            if (response.GruppiAssociati.Any() || response.GruppiCreati.Any() || response.AltriGruppi.Any())
            {
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet("gruppi-master-data/{userId}")]
        public async Task<IActionResult> GetGruppiMasterData(string userId)
        {
            var gruppi = await _gruppoService.GetGruppiMasterDataAsync(userId);
            return Ok(gruppi);
        }
    }
}
