using e_Government.Application.UseCases.AboutLegalEntity.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace e_Government.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Token")]
        public async Task<IActionResult> Token([FromForm]TokenCommand tokenCommand)
        {
            var response = await _mediator.Send(tokenCommand);

            return Ok(response);
        }

    }
}
