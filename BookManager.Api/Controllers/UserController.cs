using BookManager.Application.Commands.CreateUser;
using BookManager.Application.Commands.DeleteUser;
using BookManager.Application.Commands.LoginUser;
using BookManager.Application.Queries.GetAllUser;
using BookManager.Application.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.Api.Controllers
{
    [Route("api/user")]
    [Authorize]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            var userId = await _mediator.Send(command);

            if (userId == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetUserById), new { id = userId }, null);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAllUser()
        {
            var users = await _mediator.Send(new GetAllUserQuery());

            if (users == null || !users.Any())
            {
                return NoContent();
            }

            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var command = new GetUserByIdQuery(id);

            var user = await _mediator.Send(command);

            if (user == null)
            {
                return NoContent();
            }

            return Ok(user);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            var command = new DeleteUserCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var loginResponse = await _mediator.Send(command);

            if (loginResponse == null)
            {
                return BadRequest();
            }

            return Ok(loginResponse);
        }
    }
}
