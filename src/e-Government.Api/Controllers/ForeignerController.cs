using e_Government.Application.UseCases.AboutForeigner.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_Government.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForeignerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ForeignerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Registr(ForeignerRegistrCommand registrCommand)
        {
            var respons = _mediator.Send(registrCommand);

            return Ok(respons);
        }
            
    }
}
