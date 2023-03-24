using e_Government.Application.Abstractions;
using e_Government.Application.DIOs;
using e_Government.Application.Exeptions;
using e_Government.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_Government.Application.UseCases.AboutPopulation.Queries
{
    public class GetPopulationByPassportQuery : IQuery<ResponsePopulationModel>
    {
        public string PassportSerialNumber { get; set; }
    }

    public class GetPopulationByPassportQueryHandler : IQueryHandler<GetPopulationByPassportQuery, ResponsePopulationModel>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IBringAddressService _bringAddressService;

        public GetPopulationByPassportQueryHandler(IApplicationDbContext dbContext, IBringAddressService bringAddressService)
        {
            _dbContext = dbContext;
            _bringAddressService = bringAddressService;
        }
        public async Task<ResponsePopulationModel> Handle(GetPopulationByPassportQuery request, CancellationToken cancellationToken)
        {
            var populationPassport = await _dbContext.Passports
                .Include(x => x.Population)
                .ThenInclude(x => x.PopulationAddresses)
                .FirstOrDefaultAsync(x => x.SerialNumber == request.PassportSerialNumber, cancellationToken);

            if (populationPassport == null)
            {
                throw new PassportNotFoundException();
            }                

            return new ResponsePopulationModel
            {
                PopulationId = populationPassport.PopulationId,
                FirstName = populationPassport.Population.FirstName,
                LastName = populationPassport.Population.LastName,
                MidleName = populationPassport.Population.MidleName,
                Gender = populationPassport.Population.Gender,
                Birthday = populationPassport.Population.Birthday,
                Nationality = populationPassport.Population.NationalityName,

                Passports = populationPassport.Population.Pasports.Select(x => new DocumentViewModel
                {
                    Id = x.Id,
                    SerialNumber = x.SerialNumber,
                    DateOfIssue = x.DateOfIssue,
                    ValidityPeriod = x.ValidityPeriod,
                    StoppedDate = x.StoppedDate,
                    IsValidity = x.IsValidity,
                    IsLast = x.IsLast,
                    BelongsCountryName = x.BelongsCountryName
                }).OrderBy(x => x.Id).ToList(),

                Addresses = populationPassport.Population.PopulationAddresses.Select(x => new AddressViewModel
                {
                    Id = x.Id,
                    BuildingNumber = _bringAddressService.BringFullAddress(x.Id).BuildingNumber,
                    StreetName = _bringAddressService.BringFullAddress(x.Id).StreetName,
                    CityName = _bringAddressService.BringFullAddress(x.Id).CityName,
                    StartDateOfUse = x.StartDateOfUse,
                    EndDateOfUse = x.EndDateOfUse,
                    IsLastAddress = x.IsLastAddress
                }).OrderBy(x => x.Id).ToList()               
            };
        }
    }
}
