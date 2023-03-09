using e_Government.Application.Abstractions;
using e_Government.Application.DIOs;
using e_Government.Application.Exeptions;
using Microsoft.EntityFrameworkCore;

namespace e_Government.Application.UseCases.AboutPopulation.Queries
{
    public class GetPopulationByIdQuery : IQuery<ResponsePopulationModel>
    {
        public int Id { get; set; }
    }

    public class GetPopulationByIdQueryHandler : IQueryHandler<GetPopulationByIdQuery, ResponsePopulationModel>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IBringAddressService _bringAddressService;

        public GetPopulationByIdQueryHandler(IApplicationDbContext dbContext, IBringAddressService bringAddressService)
        {
            _dbContext = dbContext;
            _bringAddressService = bringAddressService;
        }

        public async Task<ResponsePopulationModel> Handle(GetPopulationByIdQuery request, CancellationToken cancellationToken)
        {
            var population = await _dbContext.Populations.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (population == null)
            {
                throw new PopulationNotFoundException();
            }

            var populationAddress = await _dbContext.PopulationAddresses
                .Include(x => x.Population)
                .FirstOrDefaultAsync(x => x.PopulationId == request.Id, cancellationToken);

            var populationPassport = await _dbContext.Passports
                .Include(x => x.Population)
                .FirstOrDefaultAsync(x => x.PopulationId == request.Id, cancellationToken);

            var responseAddres = _bringAddressService.BringFullAddress(populationAddress.Id);

            return new ResponsePopulationModel
            {
                PopulationId = population.Id,
                PassportSerialNumber = populationPassport.SerialNumber,
                FirstName = population.FirstName,
                LastName = population.LastName,
                MidleName = population.MidleName,
                Gender = population.Gender,
                Birthday = population.Birthday,
                Nationality = population.NationalityName,
                AddressId = populationAddress.Id,
                LocatedBuildingNumber = responseAddres.BuildingNumber,
                LocatedStreetName = responseAddres.StreetName,
                LocatedCityName = responseAddres.CityName
            };
        }
    }
}
