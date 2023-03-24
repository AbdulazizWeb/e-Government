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
                .ThenInclude(x => x.LegalEntityAddresses)
                .FirstOrDefaultAsync(x => x.SerialNumber.Contains(request.CertificateSerialNumber) && x.IsLast == true, cancellationToken);

            if (legalEntityCertificate == null)
            {
                throw new CertificateNotFoundException();
            }            

            return new ResponseLegalEntityModel
            {
                LegalEntityId = legalEntityCertificate.LegalEntityId,
                Name = legalEntityCertificate.LegalEntity.Name,
                Direction = legalEntityCertificate.LegalEntity.Direction,

                Certificates = legalEntityCertificate.LegalEntity.Certificates.Select(x => new DocumentViewModel
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
                Addresses = legalEntityCertificate.LegalEntity.LegalEntityAddresses.Select(x => new AddressViewModel
                {
                    Id = x.Id,
                    BuildingNumber = _bringAddressService.BringFullAddress(x.Id).BuildingNumber,
                    StreetName = _bringAddressService.BringFullAddress(x.Id).StreetName,
                    CityName = _bringAddressService.BringFullAddress(x.Id).CityName,
                    StartDateOfUse = x.StartDateOfUse,
                    EndDateOfUse = x.EndDateOfUse,
                    IsLastAddress = x.IsLastAddress
                }).OrderBy(x => x.Id).ToList(),
            };
        }
    }
}