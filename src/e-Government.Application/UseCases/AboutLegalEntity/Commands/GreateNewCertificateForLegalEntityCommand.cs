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
            var legalEntity = await _dbContext.LegalEntities.FirstOrDefaultAsync(x => x.Name == request.Name && x.Direction == request.Direction);

            if (legalEntity == null)
            {
                throw new LegalEntityNotFoundException();
            }

            var oldCertificate = await _dbContext.Certificates
                .Include(x => x.LegalEntity)
                .FirstOrDefaultAsync(x => x.LegalEntity.Name == request.Name && x.IsLast == true);

            oldCertificate.IsLast = false;
            oldCertificate.StoppedDate = DateTime.UtcNow;
            oldCertificate.IsValidity = false;

            var newCertificate = new Certificate
            {
                LegalEntity = legalEntity,
                DateOfIssue = DateTime.UtcNow,
                ValidityPeriod = DateTime.UtcNow.AddYears(1),
                IsValidity = true,
                IsLast = true,
                BelongsCountryName = BelongsCountryName.Uzbekistan
            };

            var number = _generateSerialNumber.Generate(new GenerateSerialNumberServiceModel
            {
                EntityId = oldCertificate.LegalEntityId,
                DocumentId = newCertificate.Id,
            });

            newCertificate.SerialNumber = "C" + number;

            _dbContext.Certificates.Update(oldCertificate);

            await _dbContext.Certificates.AddAsync(newCertificate, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return newCertificate.SerialNumber;
        }
    }
}
