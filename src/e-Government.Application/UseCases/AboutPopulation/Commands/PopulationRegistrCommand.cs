using e_Government.Application.Abstractions;
using e_Government.Application.DIOs;
using e_Government.Application.Exeptions;
using e_Government.Domain.Entities;
using e_Government.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace e_Government.Application.UseCases.AboutPopulation.Commands
{
    public class PopulationRegistrCommand : ICommand<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MidleName { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public Nationality Nationality { get; set; }
        public BelongsCountryName BelongsCountryName { get; set; }
        public string LocatedBuildingNumber { get; set; }
        public string LocatedStreetName { get; set; }
        public string LocatedCityName { get; set; }
    }
    public class PopulationRegistrCommandHandler : ICommandHandler<PopulationRegistrCommand, string>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IBringAddressService _bringAddress;
        private readonly IGenerateSerialNumberService _generateSerialNumber;
        private readonly IGetHostConsentService _getHostConsentService;

        public PopulationRegistrCommandHandler(IApplicationDbContext dbContext, IBringAddressService bringAddress, IGenerateSerialNumberService generateSerialNumber, IGetHostConsentService getHostConsentService)
        {
            _dbContext = dbContext;
            _bringAddress = bringAddress;
            _generateSerialNumber = generateSerialNumber;
            _getHostConsentService = getHostConsentService;
        }

        public async Task<string> Handle(PopulationRegistrCommand request, CancellationToken cancellationToken)
        {

            if (await _dbContext.Populations.AnyAsync(x => x.FirstName == request.FirstName && x.LastName == request.LastName && x.MidleName == request.MidleName, cancellationToken))
            {
                throw new PopulationDublicationException();
            }

            var responseAddress = _bringAddress.BringAddressId(new RequestAddressModel
            {
                BuildingNumber = request.LocatedBuildingNumber,
                StreetName = request.LocatedStreetName,
                CityName = request.LocatedCityName
            });
            var hostDocument = await _dbContext.Documents.FirstOrDefaultAsync(x => x.SerialNumber.Contains(responseAddress.HostId.ToString()) && x.IsValidity == true, cancellationToken);

            var consentFromHost = _getHostConsentService.GetHostConsent(new RequestGetHostConsentModel
            {
                HostDocumentSerialNumber = hostDocument.SerialNumber,
                MessageForHost = $"{request.FirstName} wants to register from your house with address ID {responseAddress.Id}, please let me know your reaction."
            });

            if (consentFromHost == false)
            {
                throw new HostDessagreeException();
            }

            var population = new Population
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                MidleName = request.MidleName,
                Gender = request.Gender,
                Birthday = request.Birthday,
                NationalityName = request.Nationality,
            };

            var passport = new Passport
            {
                Population = population,
                DateOfIssue = DateTime.UtcNow,
                ValidityPeriod = DateTime.UtcNow.AddYears(1),
                IsValidity = true,
                IsLast = true,
                BelongsCountryName = request.BelongsCountryName
            };

            var address = new PopulationAddress
            {
                Population = population,
                AddressIdFromCadastre = responseAddress.Id,
                StartDateOfUse = DateTime.UtcNow,
                IsLastAddress = true
            };
            
            await _dbContext.Populations.AddAsync(population, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            var number = _generateSerialNumber.Generate(new GenerateSerialNumberServiceModel
            {
                EntityId = population.Id,
                DocumentId = passport.Id,
            });

            passport.SerialNumber = "P:" + number;
            await _dbContext.PopulationAddresses.AddAsync(address, cancellationToken);
            await _dbContext.Passports.AddAsync(passport, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return passport.SerialNumber;
        }
    }
}
