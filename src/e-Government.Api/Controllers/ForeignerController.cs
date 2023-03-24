using e_Government.Application.UseCases.AboutForeigner.Commands;
using e_Government.Application.UseCases.AboutForeigner.Queries;
using e_Government.Application.UseCases.AboutPopulation.Commands;
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
        public async Task<IActionResult> Registr([FromForm]ForeignerRegistrCommand registrCommand)
        {
            var respons = await _mediator.Send(registrCommand);

            return Ok(respons);
        }

        [HttpPut]
        public async Task<IActionResult> GreateNewVisa([FromForm] GreateNewVisaForForeignerCommand greateNewVisaForForeignerCommand)
        {
            var respons = await _mediator.Send(greateNewVisaForForeignerCommand);

            return Ok(respons);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var foreigners = await _mediator.Send(new GetAllForeignerQuery());

            return Ok(foreigners);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var foreigner = new GetForeignerByIdQuery { Id = id };

            var respons = await _mediator.Send(foreigner);

            return Ok(respons);
        }

        [HttpGet("{visaSerialNumber}")]
        public async Task<IActionResult> GetByViSaSerialNumber([FromRoute] string visaSerialNumber)
        {
            var request = new GetForeignerByVisaSerialNamber { VisaSerialNmumber = visaSerialNumber };

            var respons = await _mediator.Send(request);

            return Ok(respons);
        }            
    }
}
