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

        public GetAllLegalEntityQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
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
                    CertificateSerialNumber = x.Certificates.FirstOrDefault(x => x.IsLast).SerialNumber,
                    AddressId = x.LegalEntityAddresses.FirstOrDefault(x => x.IsLastAddress).AddressIdFromCadastre

                }).OrderBy(x => x.LegalEntityId).ToListAsync(cancellationToken);
        }
    }
}
