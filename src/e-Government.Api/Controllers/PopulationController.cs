using e_Government.Application.UseCases.AboutLegalEntity.Queries;
using e_Government.Application.UseCases.AboutPopulation.Commands;
using e_Government.Application.UseCases.AboutPopulation.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace e_Government.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopulationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PopulationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("ByAdmin")]
        public async Task<IActionResult> Registr([FromForm] PopulationRegistrByAdminCommand registrByAdminCommand)
        {
            var response = await _mediator.Send(registrByAdminCommand);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Registr([FromForm] PopulationRegistrCommand registrCommand)
        {
            var response = await _mediator.Send(registrCommand);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> GreateNewCertificate([FromForm] GreateNewPasspotrForPopulationCommand greateNewPassportCommand)
        {
            var response = await _mediator.Send(greateNewPassportCommand);

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var query = new GetPopulationByIdQuery { Id = id };

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet("{passportSerialNumber}")]
        public async Task<IActionResult> GetByCertificate([FromRoute]string passportSerialNumber)
        {
            var query = new GetPopulationByPassportQuery { PassportSerialNumber = passportSerialNumber };

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllPopulationQuery());

            return Ok(response);
        }
    }
}
