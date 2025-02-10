using BookManager.Application.Commands.CreateLoan;
using BookManager.Application.Commands.CreateReturnBook;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers
{
    [Route("api/loan")]
    [ApiController]
    [Authorize]
    public class LoanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateLoan([FromBody] CreateLoanCommand command)
        {
            var loan = await _mediator.Send(command);

            if (loan == null)
            {
                return NotFound();
            }

            return Ok(loan);
        }

        [HttpPost("return-book")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> ReturnBook([FromBody] CreateReturnBookCommand command)
        {
            var loan = await _mediator.Send(command);

            if (loan != null)
            {
                return Ok("book ok");
            }

            return BadRequest("Failed to return book");
        }
    }
}
