using e_Government.Application.Abstractions;
using e_Government.Application.DIOs;
using e_Government.Application.Exeptions;
using e_Government.Domain.Entities;
using e_Government.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace e_Government.Application.UseCases.AboutPopulation.Commands
{
    public class PopulationRegistrByAdminCommand : ICommand<string>
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
    public class PopulationRegistrByAdminCommandHandler : ICommandHandler<PopulationRegistrByAdminCommand, string>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IBringAddressService _bringAddress;
        private readonly IGenerateSerialNumberService _generateSerialNumber;

        public PopulationRegistrByAdminCommandHandler(IApplicationDbContext dbContext, IBringAddressService bringAddress, IGenerateSerialNumberService generateSerialNumber)
        {
            _dbContext = dbContext;
            _bringAddress = bringAddress;
            _generateSerialNumber = generateSerialNumber;
        }

        public async Task<string> Handle(PopulationRegistrByAdminCommand request, CancellationToken cancellationToken)
        {

            if (await _dbContext.Populations.AnyAsync(x => x.FirstName == request.FirstName && x.LastName == request.LastName && x.MidleName == request.MidleName))
            {
                throw new PopulationDublicationException();
            }

            var responseAddress = _bringAddress.BringAddressId(new RequestAddressModel
            {
                BuildingNumber = request.LocatedBuildingNumber,
                StreetName = request.LocatedStreetName,
                CityName = request.LocatedCityName
            });

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
