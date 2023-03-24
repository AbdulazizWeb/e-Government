using e_Government.Domain.Enums;

namespace e_Government.Application.DIOs
{
    public class ResponseLegalEntityModel
    {
        public int LegalEntityId { get; set; }
        public string Name { get; set; }
        public Direction Direction { get; set; }
        public List<DocumentViewModel> Certificates { get; set; }
        public List<AddressViewModel> Addresses { get; set; }        
    }
}
