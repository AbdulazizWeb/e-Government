using e_Government.Application.Abstractions;
//using e_Government.Application.UseCases.LegalEntity.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace e_Goverment.Application.Tests.Commands
{
    public class LegalEntityRegistrCommandTests : IClassFixture<DependicsyInjection>
    {
        private readonly IApplicationDbContext _dbContext;

        public LegalEntityRegistrCommandTests(DependicsyInjection dependicsyInjection)
        {
            _dbContext = dependicsyInjection.ServiceProvider.GetRequiredService<IApplicationDbContext>();
        }
        [Fact]
        public async Task LegalEntityRegistrCommand_Registrates_LegalEntity()
        {
            //Arrange
            /*var cancellationToken = new CancellationTokenSource().Token;

            var command = new LegalEntityRegistrCommand()
            {
                Name = "GeneralHospital",
                Direction = Direction.Hospital,
                LocatedBuildingNumber = "A1",
                LocatedStreetName = "Amir Temur",
                LocatedCityName = "Tashkent"
            };

            var handler = new LegalEntityRegistrCommandHandler(_dbContext);*/

            //Act
            /*await handler.Handle(command, cancellationToken);*/

            //Assert


        }
    }
}

/*public string Name { get; set; }
        public Direction Direction { get; set; }
        public string LocatedBuildingNumber { get; set; }
        public string LocatedStringName { get; set; }
        public string LocatedCityName { get; set; }*/