using e_Government.Application.Abstractions;
using e_Government.Application.DIOs;
using e_Government.Application.Exeptions;
using e_Government.Domain.Entities;
using e_Government.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace e_Government.Application.UseCases.AboutLegalEntity.Commands
{
    public class LegalEntityRegistrByAdminCommand : ICommand<string>
    {
        public string Name { get; set; }
        public Direction Direction { get; set; }
        public string LocatedBuildingNumber { get; set; }
        public string LocatedStreetName { get; set; }
        public string LocatedCityName { get; set; }
    }

    public class LegalEntityRegistrByAdminCommandHandler : ICommandHandler<LegalEntityRegistrByAdminCommand, string>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IBringAddressService _bringAddress;
        private readonly IGenerateSerialNumberService _generateSerialNumber;

        public LegalEntityRegistrByAdminCommandHandler(IApplicationDbContext dbContext, IBringAddressService bringAddress, IGenerateSerialNumberService generateSerialNumber)
        {
            _dbContext = dbContext;
            _bringAddress = bringAddress;
            _generateSerialNumber = generateSerialNumber;
        }

        public async Task<string> Handle(LegalEntityRegistrByAdminCommand request, CancellationToken cancellationToken)
        {

            if (await _dbContext.LegalEntities.AnyAsync(x => x.Name == request.Name && x.Direction == request.Direction))
            {
                throw new LegalEntityDublicationException();
            }

            var responseAddress = _bringAddress.BringAddressId(new RequestAddressModel
            {
                BuildingNumber = request.LocatedBuildingNumber,
                StreetName = request.LocatedStreetName,
                CityName = request.LocatedCityName
            });

            var legalEntity = new LegalEntity
            {
                Name = request.Name,
                Direction = request.Direction,
            };

            var certificate = new Certificate
            {
                LegalEntity = legalEntity,
                DateOfIssue = DateTime.UtcNow,
                ValidityPeriod = DateTime.UtcNow.AddYears(1),
                IsValidity = true,
                IsLast = true,
                BelongsCountryName = BelongsCountryName.Uzbekistan
            };
                        
            var address = new LegalEntityAddress
            {
                LegalEntity = legalEntity,
                AddressIdFromCadastre = responseAddress.Id,
                StartDateOfUse = DateTime.UtcNow,
                IsLastAddress = true
            };

            await _dbContext.Addresses.AddAsync(address, cancellationToken);
            await _dbContext.LegalEntities.AddAsync(legalEntity, cancellationToken);
            await _dbContext.Certificates.AddAsync(certificate, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            var number = _generateSerialNumber.Generate(new GenerateSerialNumberServiceModel
            {
                EntityId = legalEntity.Id,
                DocumentId = certificate.Id,
            });

            certificate.SerialNumber = "C:" + number;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return certificate.SerialNumber;
        }
    }
}
