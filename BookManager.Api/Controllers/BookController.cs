using BookManager.Application.Commands.CreateBook;
using BookManager.Application.Commands.DeleteBook;
using BookManager.Application.Queries.GetAllBooks;
using BookManager.Application.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers
{
    [Route("api/book")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("createBook")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookCommand command)
        {
            if (command == null)
            {
                return BadRequest("Body is null");
            }

            var bookid = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetBookById), new { id = bookid }, null);
        }

        [HttpGet]
        [Authorize(Roles = "admin, client")]
        public async Task<IActionResult> GetAllBook()
        {
            var books = await _mediator.Send(new GetAllBooksQuery());

            if (books == null || !books.Any())
            {
                return NoContent();
            }

            return Ok(books);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin, client")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var command = new GetBookByIdQuery(id);

            var book = await _mediator.Send(command);

            if (book == null)
            {
                return NoContent();
            }

            return Ok(book);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteBookById(int id)
        {
            var command = new DeleteBookByIdCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
