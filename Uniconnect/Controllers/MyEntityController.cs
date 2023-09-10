using Microsoft.AspNetCore.Mvc;
using Repo.Ef;
using System.Threading.Tasks;
using System.Xml;

namespace UniConnect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MyEntityController : ControllerBase
    {
        private readonly IRepository<ApplicationUser> _repository;

        public MyEntityController(IRepository<ApplicationUser> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEntities()
        {
            var entities = await _repository.GetAllAsync();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEntityById(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEntity(string entity)
        {
           
            return Ok();
        }

        // Altri metodi per l'aggiornamento e l'eliminazione
    }
  
}
