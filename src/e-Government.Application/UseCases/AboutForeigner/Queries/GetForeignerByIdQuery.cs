using e_Government.Application.Abstractions;
using e_Government.Application.DIOs;
using e_Government.Application.Exeptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Government.Application.UseCases.AboutForeigner.Queries
{
    public class GetForeignerByIdQuery : IQuery<ResponseForeignerModel>
    {
        public int Id { get; set; }
    }

    public class GetForeignerByIdQueryHandler : IQueryHandler<GetForeignerByIdQuery, ResponseForeignerModel>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetForeignerByIdQueryHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseForeignerModel> Handle(GetForeignerByIdQuery request, CancellationToken cancellationToken)
        {
            var foreigner = await _dbContext.Foreigners
                .Include(x => x.Visas)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if(foreigner == null)
            {
                throw new ForeignerNotFoundException();
            }

            return new ResponseForeignerModel
            {
                ForeignerId = foreigner.Id,
                FirstName = foreigner.FirstName,
                LastName = foreigner.LastName,
                MidleName = foreigner.MidleName,
                Gender = foreigner.Gender,
                Birthday = foreigner.Birthday,
                Nationality = foreigner.NationalityName,

                Visas = foreigner.Visas.Select(x => new DocumentViewModel
                {
                    Id = x.Id,
                    SerialNumber = x.SerialNumber,
                    DateOfIssue = x.DateOfIssue,
                    ValidityPeriod = x.ValidityPeriod,
                    IsLast = x.IsLast,
                    IsValidity = x.IsValidity,
                    StoppedDate = x.StoppedDate,
                    BelongsCountryName = x.BelongsCountryName
                }).OrderBy(x => x.Id).ToList(),
            };
        }
    }
}
