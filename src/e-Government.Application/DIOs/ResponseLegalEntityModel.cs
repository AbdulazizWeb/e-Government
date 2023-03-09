using e_Government.Domain.Enums;

namespace e_Government.Application.DIOs
{
    public class ResponseLegalEntityModel
    {
        public int LegalEntityId { get; set; }
        public string Name { get; set; }
        public Direction Direction { get; set; }
        public string CertificateSerialNumber { get; set; }
        public int AddressId { get; set; }
        public string BuildingNumber { get; set; }
        public string StreetName { get; set; }
        public string CityName { get; set; }
    }
}
