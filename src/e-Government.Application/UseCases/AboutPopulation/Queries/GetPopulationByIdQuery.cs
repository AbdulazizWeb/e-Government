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
            var population = await _dbContext.Populations
                .Include(x=> x.PopulationAddresses)
                .Include(x => x.Pasports)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (population == null)
            {
                throw new PopulationNotFoundException();
            }            

            return new ResponsePopulationModel
            {
                PopulationId = population.Id,
                FirstName = population.FirstName,
                LastName = population.LastName,
                MidleName = population.MidleName,
                Gender = population.Gender,
                Birthday = population.Birthday,
                Nationality = population.NationalityName,

                Passports = population.Pasports.Select(x => new DocumentViewModel
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

                Addresses = population.PopulationAddresses.Select(x => new AddressViewModel
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
