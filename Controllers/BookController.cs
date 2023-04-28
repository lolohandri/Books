using Books.Data;
using Books.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Books.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IRepository<Book> _repository;
        public BookController(IRepository<Book> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(200,Type =typeof(IEnumerable<Book>))]
        public IActionResult GetBooks()
        {
            var books = _repository.GetAll();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(books);

        }
    }
}
