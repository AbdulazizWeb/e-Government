using e_Government.Domain.Enums;

namespace e_Government.Application.DIOs
{
    public class ResponsePopulationModel
    {
        public int PopulationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MidleName { get; set; }
        public Gender Gender { get; set; }
        public DateOnly Birthday { get; set; }
        public Nationality Nationality { get; set; }
        public List<DocumentViewModel> Passports { get; set; }
        public List<AddressViewModel> Addresses { get; set; }        
    }
}
