using e_Government.Application.Abstractions;
using e_Government.Application.DIOs;
using e_Government.Application.Exeptions;
using Microsoft.EntityFrameworkCore;

namespace e_Government.Application.UseCases.AboutLegalEntity.Queries
{
    public class GetLegalEntityByCertificateQuery : IQuery<ResponseLegalEntityModel>
    {
        public string CertificateSerialNumber { get; set; }
    }

    public class GetLegalEntityByCertificateQueryHandler : IQueryHandler<GetLegalEntityByCertificateQuery, ResponseLegalEntityModel>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IBringAddressService _bringAddressService;

        public GetLegalEntityByCertificateQueryHandler(IApplicationDbContext dbContext, IBringAddressService bringAddressService)
        {
            _dbContext = dbContext;
            _bringAddressService = bringAddressService;
        }
        public async Task<ResponseLegalEntityModel> Handle(GetLegalEntityByCertificateQuery request, CancellationToken cancellationToken)
        {
            var legalEntityCertificate = await _dbContext.Certificates
                .Include(x => x.LegalEntity)
                .FirstOrDefaultAsync(x => x.SerialNumber == request.CertificateSerialNumber, cancellationToken);

            if (legalEntityCertificate == null)
            {
                throw new CertificateNotFoundException();
            }
            var legalEntityAddress = await _dbContext.LegalAddresses
                .Include(x => x.LegalEntity)
                .FirstOrDefaultAsync(x => x.LegalEntityId == legalEntityCertificate.LegalEntityId, cancellationToken);

            var responseAddres = _bringAddressService.BringFullAddress(legalEntityAddress.Id);

            return new ResponseLegalEntityModel
            {
                LegalEntityId = legalEntityCertificate.LegalEntityId,
                Name = legalEntityCertificate.LegalEntity.Name,
                Direction = legalEntityCertificate.LegalEntity.Direction,
                CertificateSerialNumber = legalEntityCertificate.SerialNumber,
                AddressId = legalEntityAddress.Id,
                BuildingNumber = responseAddres.BuildingNumber,
                StreetName = responseAddres.StreetName,
                CityName = responseAddres.CityName
            };
        }
    }
}
