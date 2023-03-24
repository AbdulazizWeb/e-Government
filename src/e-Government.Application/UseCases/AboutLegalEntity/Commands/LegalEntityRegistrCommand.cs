using e_Government.Application.Abstractions;
using e_Government.Application.DIOs;
using e_Government.Application.Exeptions;
using e_Government.Domain.Entities;
using e_Government.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace e_Government.Application.UseCases.AboutLegalEntity.Commands
{
    public class LegalEntityRegistrCommand : ICommand<string>
    {
        public string Name { get; set; }
        public Direction Direction { get; set; }
        public string LocatedBuildingNumber { get; set; }
        public string LocatedStreetName { get; set; }
        public string LocatedCityName { get; set; }
    }

    public class LegalEntityRegistrCommandHandler : ICommandHandler<LegalEntityRegistrCommand, string>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IBringAddressService _bringAddress;
        private readonly IGenerateSerialNumberService _generateSerialNumber;
        private readonly IGetHostConsentService _getHostConsentService;

        public LegalEntityRegistrCommandHandler(IApplicationDbContext dbContext, IBringAddressService bringAddress, IGenerateSerialNumberService generateSerialNumber, IGetHostConsentService getHostConsentService)
        {
            _dbContext = dbContext;
            _bringAddress = bringAddress;
            _generateSerialNumber = generateSerialNumber;
            _getHostConsentService = getHostConsentService;
        }

        public async Task<string> Handle(LegalEntityRegistrCommand request, CancellationToken cancellationToken)
        {
            if (request.Name == "Government" || request.Name == "Hospital" || request.Name == "Economy" || request.Name == "Security" || request.Name == "Transport")
            {
                if (request.Name == "Government" && request.Direction.ToString() == "Government" || request.Name == "Hospital" && request.Direction.ToString() == "Hospital" || request.Name == "Economy" && request.Direction.ToString() == "Economy" || request.Name == "Security" && request.Direction.ToString() == "Security" || request.Name == "Transport" && request.Direction.ToString() == "Transport")
                {
                    if (await _dbContext.LegalEntities.AnyAsync(x => x.Name == request.Name && x.Direction == request.Direction, cancellationToken))
                    {
                        throw new LegalEntityDublicationException();
                    }
                }
                else
                {
                    throw new UsingMinistryNameException();
                }
            }

            if (await _dbContext.LegalEntities.AnyAsync(x => x.Name == request.Name && x.Direction == request.Direction, cancellationToken))
            {
                throw new LegalEntityDublicationException();
            }

            var responseAddress = _bringAddress.BringAddressId(new RequestAddressModel
            {
                BuildingNumber = request.LocatedBuildingNumber,
                StreetName = request.LocatedStreetName,
                CityName = request.LocatedCityName
            });

            var codForSearchFromDb = "C:" + responseAddress.HostId.ToString() + ":";

            var hostDocument = await _dbContext.Documents.FirstOrDefaultAsync(x => x.SerialNumber.Contains(codForSearchFromDb) && x.IsValidity == true, cancellationToken);

            var consentFromHost = _getHostConsentService.GetHostConsent(new RequestGetHostConsentModel
            {
                HostDocumentSerialNumber = hostDocument.SerialNumber,
                MessageForHost = $"{request.Name} wants to register from your house with address ID {responseAddress.Id}, please let me know your reaction."
            });

            if (consentFromHost == false)
            {
                throw new HostDessagreeException();
            }

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
                BelongsCountryName = BelongsCountryName.Uzbekistan,
                SerialNumber = "C:"
            };

            var address = new LegalEntityAddress
            {
                LegalEntity = legalEntity,
                AddressIdFromCadastre = responseAddress.Id,
                StartDateOfUse = DateTime.UtcNow,
                IsLastAddress = true
            };

            await _dbContext.Certificates.AddAsync(certificate, cancellationToken);
            await _dbContext.LegalEntities.AddAsync(legalEntity, cancellationToken);
            await _dbContext.LegalAddresses.AddAsync(address, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            var number = _generateSerialNumber.Generate(new GenerateSerialNumberServiceModel
            {
                EntityId = legalEntity.Id,
                DocumentId = certificate.Id,
            });

            certificate.SerialNumber += number;            

            await _dbContext.SaveChangesAsync(cancellationToken);

            return certificate.SerialNumber;
        }
    }
}
