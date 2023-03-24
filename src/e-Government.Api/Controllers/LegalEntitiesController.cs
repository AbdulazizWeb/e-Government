using e_Government.Application.UseCases.AboutLegalEntity.Commands;
using e_Government.Application.UseCases.AboutLegalEntity.Queries;
using e_Government.Application.UseCases.AboutPopulation.Queries;
using e_Government.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace e_Government.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LegalEntitiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LegalEntitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("ByAdmin")]
        public async Task<IActionResult> Registr([FromForm] LegalEntityRegistrByAdminCommand registrByAdminCommand)
        {
            var response = await _mediator.Send(registrByAdminCommand);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Registr([FromForm] LegalEntityRegistrCommand registrCommand)
        {
            var response = await _mediator.Send(registrCommand);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> GreateNewCertificate([FromForm] GreateNewCertificateForLegalEntityCommand greateNewCertificateCommand)
        {
            var response = await _mediator.Send(greateNewCertificateCommand);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetByName(Direction direction, string name)
        {
            var query = new GetLegalEntityByNameQuery
            {
                Name = name,
                Direction = direction
            };
            
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var query = new GetLegalEntityByIdQuery { Id = id };

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet("{certificateSerialNumber}")]
        public async Task<IActionResult> GetByCertificate([FromRoute]string certificateSerialNumber)
        {
            var query = new GetLegalEntityByCertificateQuery { CertificateSerialNumber = certificateSerialNumber };

            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllLegalEntityQuery());

            return Ok(response);
        }
    }
}
