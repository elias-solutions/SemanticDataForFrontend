namespace Api.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Api.DataAccess.Repository;
    using Extensions.Pack;
    using Microsoft.AspNetCore.Mvc;
    using Models.Car;

    [Route("api/v1/cars")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly Repository<CarModel> _repo;

        public CarController(Repository<CarModel> repo)
        {
            _repo = repo;


        }

        [HttpGet]
        public async Task<ActionResult> GetAsync([FromQuery] params Guid[] identifiers)
        {
            var result = await _repo.GetAsync(identifiers);
            return Ok(result.ToArray());
        }

        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] CarModel item)
        {
            await _repo.AddAsync(item);
            return Ok("Successfully saved.");
        }


        [HttpPut("{identifier}")]
        public async Task<ActionResult> UpdateAsync(Guid identifier, [FromBody] CarModel item)
        {
            var model = _repo.GetAsync(identifier);
            if (model.IsNull())
            {
                return BadRequest($"Object with '{identifier}' does not exist.");
            }

            await _repo.UpdateAsync(item);
            return Ok();
        }

        [HttpDelete("{identifier}")]
        public async Task<ActionResult> DeleteAsync(Guid identifier)
        {
            var model = await _repo.GetAsync(identifier);
            if (model.IsEmpty())
            {
                return BadRequest($"Object with '{identifier}' does not exist.");
            }

            await _repo.DeleteAsync(model.ToArray());
            return Ok();
        }
    }
}