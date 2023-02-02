using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiMySQLNetCore.Data.Repositories;
using WebApiMySQLNetCore.Models;

namespace WebApiMySQLNetCore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            return Ok(await _carRepository.GetAllCars());
        }
        
        [HttpGet("{idCar}")]
        public async Task<IActionResult> GetAllCars(int idCar)
        {
            return Ok(await _carRepository.GetByIdCar(idCar));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCars([FromBody] CarModel item)
        {
            if (item == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdCar = await _carRepository.InsertCar(item);

            return Created("created", createdCar);
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateCar([FromBody] CarModel item)
        {
            if (item == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            await _carRepository.UpdateByIdCar(item);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCars(int id)
        {
            await _carRepository.DeleteCar(new CarModel() {IdCar = id});

            return NoContent();
        }
    }
}