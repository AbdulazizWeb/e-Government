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
        private readonly IBringAddressService _bringAddressService;

        public GetAllPopulationQueryHandler(IApplicationDbContext dbContext, IBringAddressService bringAddressService)
        {
            _dbContext = dbContext;
            _bringAddressService = bringAddressService;
        }

        public async Task<List<ResponsePopulationModel>> Handle(GetAllPopulationQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Populations
                .Include(x => x.Pasports)
                .Include(x => x.PopulationAddresses)
                .Select(x => new ResponsePopulationModel
                {
                    PopulationId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    MidleName = x.MidleName,
                    Gender = x.Gender,
                    Birthday = x.Birthday,
                    Nationality = x.NationalityName,

                    Passports = x.Pasports.Select(x => new DocumentViewModel
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

                    Addresses = x.PopulationAddresses.Select(x => new AddressViewModel
                    {
                        Id = x.Id,
                        BuildingNumber = _bringAddressService.BringFullAddress(x.Id).BuildingNumber,
                        StreetName = _bringAddressService.BringFullAddress(x.Id).StreetName,
                        CityName = _bringAddressService.BringFullAddress(x.Id).CityName,
                        StartDateOfUse = x.StartDateOfUse,
                        EndDateOfUse = x.EndDateOfUse,
                        IsLastAddress = x.IsLastAddress
                    }).OrderBy(x => x.Id).ToList()

                }).OrderBy(x => x.PopulationId).ToListAsync(cancellationToken);
        }
    }
}
