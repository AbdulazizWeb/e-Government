using e_Government.Application.Abstractions;
using e_Government.Application.DIOs;
using e_Government.Application.Exeptions;
using e_Government.Domain.Entities;
using e_Government.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace e_Government.Application.UseCases.AboutPopulation.Commands
{
    public class GreateNewPasspotrForPopulationCommand : ICommand<string>
    {
        public string LastPassportSerialNumber { get; set; }
    }

    public class GreateNewPasspotrForPopulationCommandHandler : ICommandHandler<GreateNewPasspotrForPopulationCommand, string>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IGenerateSerialNumberService _generateSerialNumber;

        public GreateNewPasspotrForPopulationCommandHandler(IApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<string> Handle(GreateNewPasspotrForPopulationCommand request, CancellationToken cancellationToken)
        {
            var lastPassport = await _dbContext.Passports
                .Include(x => x.Population)
                .FirstOrDefaultAsync(x => x.SerialNumber == request.LastPassportSerialNumber,cancellationToken);

            if (lastPassport == null)
            {
                throw new PassportNotFoundException();
            }
            
            lastPassport.IsLast = false;
            lastPassport.StoppedDate = DateTime.UtcNow;
            lastPassport.IsValidity = false;


            var newPassport = new Passport
            {
                Population = lastPassport.Population,
                DateOfIssue = DateTime.UtcNow,
                ValidityPeriod = DateTime.UtcNow.AddYears(1),
                IsValidity = true,
                IsLast = true,
                BelongsCountryName = lastPassport.BelongsCountryName,
                SerialNumber = "P:" 
            };

            await _dbContext.Passports.AddAsync(newPassport, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            var number = _generateSerialNumber.Generate(new GenerateSerialNumberServiceModel
            {
                EntityId = lastPassport.PopulationId,
                DocumentId = newPassport.Id,
            });

            newPassport.SerialNumber += number;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return newPassport.SerialNumber;
        }
    }
}
