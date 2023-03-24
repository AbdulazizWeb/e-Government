using e_Government.Application.Abstractions;
using e_Government.Application.DIOs;
using e_Government.Application.Exeptions;
using Microsoft.EntityFrameworkCore;

namespace e_Government.Application.UseCases.AboutLegalEntity.Queries
{
    public class GetLegalEntityByIdQuery : IQuery<ResponseLegalEntityModel>
    {
        public int Id { get; set; }
    }

    public class GetLegalEntityByIdQueryHandler : IQueryHandler<GetLegalEntityByIdQuery, ResponseLegalEntityModel>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IBringAddressService _bringAddressService;

        public GetLegalEntityByIdQueryHandler(IApplicationDbContext dbContext, IBringAddressService bringAddressService)
        {
            _dbContext = dbContext;
            _bringAddressService = bringAddressService;
        }

        public async Task<ResponseLegalEntityModel> Handle(GetLegalEntityByIdQuery request, CancellationToken cancellationToken)
        {
            var legalEntity = await _dbContext.LegalEntities
                .Include(x => x.LegalEntityAddresses)
                .Include(x => x.Certificates)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (legalEntity == null)
            {
                throw new LegalEntityNotFoundException();
            }
            
            var responseAddres = _bringAddressService.BringFullAddress(legalEntity.LegalEntityAddresses.FirstOrDefault(x => x.IsLastAddress == true).Id);

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
                }).OrderBy(x => x.Id).ToList()                
            };
        }
    }
}
