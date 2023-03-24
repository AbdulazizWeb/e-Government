using e_Government.Application.Abstractions;
using e_Government.Application.DIOs;
using e_Government.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Government.Application.UseCases.AboutForeigner.Queries
{
    public class GetAllForeignerQuery : IQuery<List<ResponseForeignerModel>>
    {
    }

    public class GetAllForeignerQueryHandler : IQueryHandler<GetAllForeignerQuery, List<ResponseForeignerModel>>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetAllForeignerQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<ResponseForeignerModel>> Handle(GetAllForeignerQuery request, CancellationToken cancellationToken)
        {
           return await _dbContext.Foreigners
                .Include(x => x.Visas)
                .Select(x => new ResponseForeignerModel
                {
                    ForeignerId = x.Id,                    
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    MidleName = x.MidleName,
                    Gender = x.Gender,
                    Birthday = x.Birthday,
                    Nationality = x.NationalityName,

                    Visas = x.Visas.Select(x => new DocumentViewModel
                    {
                        Id = x.Id,
                        SerialNumber = x.SerialNumber,
                        DateOfIssue = x.DateOfIssue,
                        ValidityPeriod = x.ValidityPeriod,
                        StoppedDate = x.StoppedDate,
                        IsValidity = x.IsValidity,
                        IsLast = x.IsLast,
                        BelongsCountryName = x.BelongsCountryName
                    }).OrderBy(x => x.Id).ToList()
                }).ToListAsync(cancellationToken);
        }
    }
}
