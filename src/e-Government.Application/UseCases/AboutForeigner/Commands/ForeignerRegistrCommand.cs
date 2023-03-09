using e_Government.Application.Abstractions;
using e_Government.Application.DIOs;
using e_Government.Application.Exeptions;
using e_Government.Domain.Entities;
using e_Government.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Government.Application.UseCases.AboutForeigner.Commands
{
    public class ForeignerRegistrCommand : ICommand<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MidleName { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public Nationality Nationality { get; set; }
        public BelongsCountryName BelongsCountry { get; set; }
    }

    public class ForeignerRegistrCommandHandler : ICommandHandler<ForeignerRegistrCommand, string>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IGenerateSerialNumberService _generateSerialNumberService;

        public ForeignerRegistrCommandHandler(IApplicationDbContext dbContext, IGenerateSerialNumberService generateSerialNumberService)
        {
            _dbContext = dbContext;
            _generateSerialNumberService = generateSerialNumberService;
        }
        public async Task<string> Handle(ForeignerRegistrCommand request, CancellationToken cancellationToken)
        {
            if (await _dbContext.Foreigners.AnyAsync(x => x.FirstName == request.FirstName && x.LastName == request.LastName && x.MidleName == request.MidleName && x.Birthday == request.Birthday, cancellationToken))
            {
                throw new ForeignerDublicationException();
            }

            var foreigner = new Foreigner
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                MidleName = request.MidleName,
                Gender = request.Gender,
                Birthday = request.Birthday,
                NationalityName = request.Nationality
            };

            var visa = new Visa
            {
                Foreigner = foreigner,
                DateOfIssue = DateTime.UtcNow,
                ValidityPeriod = DateTime.UtcNow.AddYears(1),
                IsLast = true,
                IsValidity = true,
                BelongsCountryName = request.BelongsCountry
            };

            var number = _generateSerialNumberService.Generate(new GenerateSerialNumberServiceModel
            {
                EntityId = foreigner.Id,
                DocumentId = visa.Id,
            });

            visa.SerialNumber = "V:" + number;

            await _dbContext.Visas.AddAsync(visa, cancellationToken);
            await _dbContext.Foreigners.AddAsync(foreigner, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return visa.SerialNumber;
        }
    }
}
