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
        private readonly IBringAddressService _bringAddress;

        public GetLegalEntityByNameQueryHandler(IApplicationDbContext context, IBringAddressService bringAddress)
        {
            _dbContext = context;
            _bringAddress = bringAddress;
        }

        public async Task<ResponseLegalEntityModel> Handle(GetLegalEntityByNameQuery request, CancellationToken cancellationToken)
        {
            var legalEntity = await _dbContext.LegalEntities.FirstOrDefaultAsync(x => x.Name == request.Name && x.Direction == request.Direction);

            if (legalEntity == null)
            {
                throw new LegalEntityNotFoundException();
            }

            var legalEntityAddress = await _dbContext.LegalAddresses
                .Include(x => x.LegalEntity)
                .FirstOrDefaultAsync(x => x.LegalEntity.Name == request.Name && x.LegalEntity.Direction == request.Direction, cancellationToken);

            var legalEntityCertificate = await _dbContext.Certificates
                .Include(x => x.LegalEntity)
                .FirstOrDefaultAsync(x => x.LegalEntity.Name == request.Name && x.LegalEntity.Direction == request.Direction, cancellationToken);

            var responseAddres = _bringAddress.BringFullAddress(legalEntityAddress.Id);

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
