using e_Government.Application.Abstractions;
using e_Government.Application.Exeptions;
using e_Government.Domain.Entities;
using e_Government.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace e_Government.Application.UseCases.AboutLegalEntity.Commands
{
    public class TokenCommand : IRequest<string>
    {
        public string MinistryName { get; set; }
        public Direction Direction { get; set; }        
    }

    public class TokenCommandHandler : IRequestHandler<TokenCommand, string>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly ITokenService _tokenService;        

        public TokenCommandHandler(IApplicationDbContext dbContext, ITokenService tokenService)
        {
            _dbContext = dbContext;
            _tokenService = tokenService;
        }

        public async Task<string> Handle(TokenCommand request, CancellationToken cancellationToken)
        {
            if (request.MinistryName == "Government" || request.MinistryName == "Hospital" || request.MinistryName == "Economy" || request.MinistryName == "Security" || request.MinistryName == "Transport")
            {
                if (!await _dbContext.LegalEntities.AnyAsync(x => x.Name == request.MinistryName, cancellationToken))
                {
                    throw new LegalEntityNotFoundException();
                }
            }
            else
            {
                throw new TokenException();
            } 
                

            var ministry = await _dbContext.LegalEntities
                .Include(x => x.Certificates)
                .FirstOrDefaultAsync(x => x.Name == request.MinistryName, cancellationToken);

            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier, ministry.Id.ToString()),
                new (ClaimTypes.Name, ministry.Name),
                new (ClaimTypes.SerialNumber, ministry.Certificates.FirstOrDefault(x => x.IsLast == true).SerialNumber.ToString()),
                new (ClaimTypes.Country, ministry.Certificates.FirstOrDefault(x => x.IsLast == true).BelongsCountryName.ToString())
            };

            return _tokenService.GetAcessToken(claims.ToArray());
        }
    }
}
