using e_Government.Application.Abstractions;
using e_Government.Application.DIOs;
using e_Government.Application.Exeptions;
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
                .FirstOrDefaultAsync(x => x.SerialNumber == request.PassportSerialNumber, cancellationToken);

            if (populationPassport == null)
            {
                throw new PassportNotFoundException();
            }
            var populationAddress = await _dbContext.PopulationAddresses
                .Include(x => x.Population)
                .FirstOrDefaultAsync(x => x.PopulationId == populationPassport.PopulationId, cancellationToken);

            var responseAddres = _bringAddressService.BringFullAddress(populationAddress.Id);

            return new ResponsePopulationModel
            {
                PopulationId = populationPassport.PopulationId,
                PassportSerialNumber = populationPassport.SerialNumber,
                FirstName = populationPassport.Population.FirstName,
                LastName = populationPassport.Population.LastName,
                MidleName = populationPassport.Population.MidleName,
                Gender = populationPassport.Population.Gender,
                Birthday = populationPassport.Population.Birthday,
                Nationality = populationPassport.Population.NationalityName,
                AddressId = populationAddress.Id,
                LocatedBuildingNumber = responseAddres.BuildingNumber,
                LocatedStreetName = responseAddres.StreetName,
                LocatedCityName = responseAddres.CityName
            };
        }
    }
}
