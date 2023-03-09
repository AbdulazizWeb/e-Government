using e_Government.Domain.Enums;

namespace e_Government.Application.DIOs
{
    public class ResponsePopulationModel
    {
        public int PopulationId { get; set; }
        public string PassportSerialNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MidleName { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public Nationality Nationality { get; set; }
        public int AddressId { get; set; }
        public string LocatedBuildingNumber { get; set; }
        public string LocatedStreetName { get; set; }
        public string LocatedCityName { get; set; }
    }
}
