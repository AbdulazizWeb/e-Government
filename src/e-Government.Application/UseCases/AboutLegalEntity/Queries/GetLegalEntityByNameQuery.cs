using e_Government.Application.Abstractions;
using e_Government.Application.DIOs;
using e_Government.Application.Exeptions;
using e_Government.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace e_Government.Application.UseCases.AboutLegalEntity.Queries
{
    public class GetLegalEntityByNameQuery : IQuery<ResponseLegalEntityModel>
    {
        public string Name { get; set; }
        public Direction Direction { get; set; }
    }

    public class GetLegalEntityByNameQueryHandler : IQueryHandler<GetLegalEntityByNameQuery, ResponseLegalEntityModel>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IBringAddressService _bringAddressService;

        public GetLegalEntityByNameQueryHandler(IApplicationDbContext context, IBringAddressService bringAddress)
        {
            _dbContext = context;
            _bringAddressService = bringAddress;
        }

        public async Task<ResponseLegalEntityModel> Handle(GetLegalEntityByNameQuery request, CancellationToken cancellationToken)
        {
            var legalEntity = await _dbContext.LegalEntities
                .Include(x => x.Certificates)
                .Include(x => x.LegalEntityAddresses)
                .FirstOrDefaultAsync(x => x.Name == request.Name && x.Direction == request.Direction);

            if (legalEntity == null)
            {
                throw new LegalEntityNotFoundException();
            }
            
            return new ResponseLegalEntityModel
            {
                LegalEntityId = legalEntity.Id,
                Name = legalEntity.Name,
                Direction = legalEntity.Direction,

                Certificates = legalEntity.Certificates.Select(x => new DocumentViewModel
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

                Addresses = legalEntity.LegalEntityAddresses.Select(x => new AddressViewModel
                {
                    Id = x.Id,
                    BuildingNumber = _bringAddressService.BringFullAddress(x.Id).BuildingNumber,
                    StreetName = _bringAddressService.BringFullAddress(x.Id).StreetName,
                    CityName = _bringAddressService.BringFullAddress(x.Id).CityName,
                    StartDateOfUse = x.StartDateOfUse,
                    EndDateOfUse = x.EndDateOfUse,
                    IsLastAddress = x.IsLastAddress
                }).OrderBy(X => X.Id).ToList(),                
            };
        }
    }
}
