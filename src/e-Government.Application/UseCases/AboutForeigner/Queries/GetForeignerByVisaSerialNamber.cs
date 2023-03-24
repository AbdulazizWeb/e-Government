using e_Government.Application.Abstractions;
using e_Government.Application.DIOs;
using e_Government.Application.Exeptions;
using e_Government.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Government.Application.UseCases.AboutForeigner.Queries
{
    public class GetForeignerByVisaSerialNamber : IQuery<ResponseForeignerModel>
    {
        public string VisaSerialNmumber { get; set; }
    }

    public class GetForeignerByVisaSerialNamberHandler : IQueryHandler<GetForeignerByVisaSerialNamber, ResponseForeignerModel>
    {
        private readonly IApplicationDbContext _dbContext;

        public GetForeignerByVisaSerialNamberHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseForeignerModel> Handle(GetForeignerByVisaSerialNamber request, CancellationToken cancellationToken)
        {
            var visa = await _dbContext.Visas
                .Include(x => x.Foreigner)
                .ThenInclude(x => x.Visas)
                .FirstOrDefaultAsync(x => x.SerialNumber == request.VisaSerialNmumber, cancellationToken);

            if(visa == null)
            {
                throw new VisaNotFoundException();
            }

            return new ResponseForeignerModel
            {
                ForeignerId = visa.ForeignerId,
                FirstName = visa.Foreigner.FirstName,
                LastName = visa.Foreigner.LastName,
                MidleName = visa.Foreigner.MidleName,
                Gender = visa.Foreigner.Gender,
                Birthday = visa.Foreigner.Birthday,
                Nationality = visa.Foreigner.NationalityName,

                Visas = visa.Foreigner.Visas.Select(x => new DocumentViewModel
                {
                    Id = x.Id,
                    SerialNumber = x.SerialNumber,
                    DateOfIssue = x.DateOfIssue,
                    ValidityPeriod = x.ValidityPeriod,
                    IsLast = x.IsLast,
                    IsValidity = x.IsValidity,
                    StoppedDate = x.StoppedDate,
                    BelongsCountryName = x.BelongsCountryName
                }).OrderBy(x => x.Id).ToList()
            };
        }
    }
}
