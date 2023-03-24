using e_Government.Application.Abstractions;
using e_Government.Application.Exeptions;
using e_Government.Domain.Entities;
using e_Government.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace e_Government.Application.UseCases.AboutForeigner.Commands
{
    public class GreateNewVisaForForeignerCommand : ICommand<string>
    {
        public string OldVisaSerialNumber { get; set; }
        public BelongsCountryName BelongsCountryNameNow { get; set; }
    }

    public class GreateNewVisaForForeignerCommandHandler : ICommandHandler<GreateNewVisaForForeignerCommand, string>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IGenerateSerialNumberService _generateSerialNumber;

        public GreateNewVisaForForeignerCommandHandler(IApplicationDbContext dbContext, IGenerateSerialNumberService generateSerialNumber)
        {
            _dbContext = dbContext;
            _generateSerialNumber = generateSerialNumber;
        }

        public async Task<string> Handle(GreateNewVisaForForeignerCommand request, CancellationToken cancellationToken)
        {
            var oldVisa = await _dbContext.Visas
                .Include(x => x.Foreigner)
                .FirstOrDefaultAsync(x => x.SerialNumber == request.OldVisaSerialNumber && x.IsLast == true, cancellationToken);

            if (oldVisa == null)
            {
                throw new VisaNotFoundException();
            }

            oldVisa.StoppedDate = DateTime.UtcNow;
            oldVisa.IsLast = false;
            oldVisa.IsValidity = false;

            var newVisa = new Visa
            {
                Foreigner = oldVisa.Foreigner,
                DateOfIssue = DateTime.UtcNow,
                ValidityPeriod = DateTime.UtcNow.AddYears(1),
                IsLast = true,
                IsValidity = true,
                BelongsCountryName = request.BelongsCountryNameNow,
                SerialNumber = "V:"
            };
            await _dbContext.Visas.AddAsync(newVisa, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            var number = _generateSerialNumber.Generate(new DIOs.GenerateSerialNumberServiceModel
            {
                EntityId = newVisa.ForeignerId,
                DocumentId = newVisa.Id
            });

            newVisa.SerialNumber += number;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return newVisa.SerialNumber;
        }
    }
}
