using e_Government.Application.Abstractions;
using e_Government.Application.DIOs;
using e_Government.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_Government.Application.UseCases.AboutLegalEntity.Queries
{
    public class GetAllLegalEntityQuery : IQuery<List<ResponseLegalEntityModel>>
    {
    }
    public class GetAllLegalEntityQueryHandler : IQueryHandler<GetAllLegalEntityQuery, List<ResponseLegalEntityModel>>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IBringAddressService _bringAddressService;

        public GetAllLegalEntityQueryHandler(IApplicationDbContext dbContext, IBringAddressService bringAddressService)
        {
            _dbContext = dbContext;
            _bringAddressService = bringAddressService;
        }

        public async Task<List<ResponseLegalEntityModel>> Handle(GetAllLegalEntityQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.LegalEntities
                .Include(x => x.LegalEntityAddresses)
                .Include(x => x.Certificates)
                .Select(x => new ResponseLegalEntityModel
                {
                    LegalEntityId = x.Id,
                    Name = x.Name,
                    Direction = x.Direction,

                    Certificates = x.Certificates.Select(x => new DocumentViewModel
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

                    Addresses = x.LegalEntityAddresses.Select(x => new AddressViewModel
                    {
                        Id = x.Id,
                        BuildingNumber = _bringAddressService.BringFullAddress(x.Id).BuildingNumber,
                        StreetName = _bringAddressService.BringFullAddress(x.Id).StreetName,
                        CityName = _bringAddressService.BringFullAddress(x.Id).CityName,
                        StartDateOfUse = x.StartDateOfUse,
                        EndDateOfUse = x.EndDateOfUse,
                        IsLastAddress = x.IsLastAddress
                    }).OrderBy(x => x.Id).ToList()

                }).OrderBy(x => x.LegalEntityId).ToListAsync(cancellationToken);
        }
    }
}
