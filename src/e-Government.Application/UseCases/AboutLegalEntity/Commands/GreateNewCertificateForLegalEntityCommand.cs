using e_Government.Application.Abstractions;
using e_Government.Application.DIOs;
using e_Government.Application.Exeptions;
using e_Government.Domain.Entities;
using e_Government.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace e_Government.Application.UseCases.AboutLegalEntity.Commands
{
    public class GreateNewCertificateForLegalEntityCommand : ICommand<string>
    {
        public string Name { get; set; }
        public Direction Direction { get; set; }
        public BelongsCountryName BelongsCountryName { get; set; }
    }

    public class GreateNewCertificateForLegalEntityCommandHandler : ICommandHandler<GreateNewCertificateForLegalEntityCommand, string>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IGenerateSerialNumberService _generateSerialNumber;

        public GreateNewCertificateForLegalEntityCommandHandler(IApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<string> Handle(GreateNewCertificateForLegalEntityCommand request, CancellationToken cancellationToken)
        {
            var legalEntity = await _dbContext.LegalEntities
                .Include(x => x.Certificates)
                .FirstOrDefaultAsync(x => x.Name == request.Name && x.Direction == request.Direction, cancellationToken);

            if (legalEntity == null)
            {
                throw new LegalEntityNotFoundException();
            }

            legalEntity.Certificates.FirstOrDefault(x => x.IsLast == true).IsLast = false;
            legalEntity.Certificates.FirstOrDefault(x => x.IsLast == true).StoppedDate = DateTime.UtcNow;
            legalEntity.Certificates.FirstOrDefault(x => x.IsLast == true).IsValidity = false;
                        
            var newCertificate = new Certificate
            {
                LegalEntity = legalEntity,
                DateOfIssue = DateTime.UtcNow,
                ValidityPeriod = DateTime.UtcNow.AddYears(1),
                IsValidity = true,
                IsLast = true,
                BelongsCountryName = request.BelongsCountryName,
                SerialNumber = "C:"
            };

            await _dbContext.Certificates.AddAsync(newCertificate, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            var number = _generateSerialNumber.Generate(new GenerateSerialNumberServiceModel
            {
                EntityId = legalEntity.Id,
                DocumentId = newCertificate.Id,
            });

            newCertificate.SerialNumber += number;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return newCertificate.SerialNumber;
        }
    }
}
