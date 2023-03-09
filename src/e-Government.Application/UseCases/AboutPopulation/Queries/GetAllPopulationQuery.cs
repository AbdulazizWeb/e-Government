using e_Government.Application.Abstractions;
using e_Government.Application.DIOs;
using e_Government.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Government.Application.UseCases.AboutPopulation.Queries
{
    public class GetAllPopulationQuery : IQuery<List<ResponsePopulationModel>>
    {
    }

    public class GetAllPopulationQueryHandler : IQueryHandler<GetAllPopulationQuery, List<ResponsePopulationModel>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetAllPopulationQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ResponsePopulationModel>> Handle(GetAllPopulationQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Populations
                .Include(x => x.Pasports)
                .Include(x => x.PopulationAddresses)
                .Select(x => new ResponsePopulationModel
                {
                    PopulationId = x.Id,
                    PassportSerialNumber = x.Pasports.FirstOrDefault(x => x.IsLast == true).SerialNumber,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    MidleName = x.MidleName,
                    Gender = x.Gender,
                    Birthday = x.Birthday,
                    Nationality = x.NationalityName,
                    AddressId = x.PopulationAddresses.FirstOrDefault(a => a.IsLastAddress == true).Id    
                    
                }).OrderBy(x => x.PopulationId).ToListAsync(cancellationToken);
        }
    }
}
