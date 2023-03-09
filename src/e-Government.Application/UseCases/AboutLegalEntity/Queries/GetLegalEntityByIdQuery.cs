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
            var legalEntity = await _dbContext.LegalEntities.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (legalEntity == null)
            {
                throw new LegalEntityNotFoundException();
            }

            var legalEntityAddress = await _dbContext.LegalAddresses
                .Include(x => x.LegalEntity)
                .FirstOrDefaultAsync(x => x.LegalEntityId == request.Id, cancellationToken);

            var legalEntityCertificate = await _dbContext.Certificates
                .Include(x => x.LegalEntity)
                .FirstOrDefaultAsync(x => x.LegalEntityId == request.Id, cancellationToken);

            var responseAddres = _bringAddressService.BringFullAddress(legalEntityAddress.Id);

            return new ResponseLegalEntityModel
            {
                LegalEntityId = legalEntity.Id,
                Name = legalEntity.Name,
                Direction = legalEntity.Direction,
                CertificateSerialNumber = legalEntityCertificate.SerialNumber,
                AddressId = legalEntityAddress.Id,
                BuildingNumber = responseAddres.BuildingNumber,
                StreetName = responseAddres.StreetName,
                CityName = responseAddres.CityName
            };
        }
    }
}
