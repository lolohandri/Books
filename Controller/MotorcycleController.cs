using Microsoft.AspNetCore.Mvc;
using Books.Interfaces;
using Books.Models;
using Books.Repository;

namespace Books.Controller
{
    [Route("api/motorcycles")]
    [ApiController]
    public class MotorcycleController : ControllerBase
    {
        private readonly IRepository<Motorcycle> _repository;
        private IUnitOfWork _unitOfWork;
        public MotorcycleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Motorcycle>))]
        public IActionResult GetAll()
        {
            var motorcycles = _unitOfWork.MotorcycleRepository.GetAll();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(motorcycles);
        }

        [HttpGet("{id:long}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Motorcycle>))]
        public IActionResult Get(long id)
        {
            var motorcycle = _unitOfWork.MotorcycleRepository.Get(id);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(motorcycle);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Motorcycle))]
        public IActionResult Create([FromBody] Motorcycle item)
        {
            _unitOfWork.MotorcycleRepository.Create(item);
            _unitOfWork.Save();
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok("Succesfully created");
        }

        [HttpDelete("{id:long}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public IActionResult Delete(long id)
        {
            var check = _unitOfWork.MotorcycleRepository.Delete(id);
            _unitOfWork.Save();
            if (!check)
            {
                return BadRequest("Item not found");
            }
            return Ok("Succesfully deleted");
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(bool))]
        public IActionResult Update(long id, [FromBody]Motorcycle item)
        {
            var check = _unitOfWork.MotorcycleRepository.Update(id, item);
            _unitOfWork.Save();
            if (!check)
            {
                return BadRequest("Item is null");
            }
            return Ok("Succefully updated");
        }
    }
}
