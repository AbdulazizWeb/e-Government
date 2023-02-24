using e_Government.Domain.Enums;

namespace e_Government.Domain.Entities
{
    public class LegalEntity
    {
        public LegalEntity()
        {
            Certificates = new HashSet<Certificate>();
            DocumentInformations = new HashSet<DocumentInformation>();
            LegalEntityAddresses = new HashSet<LegalEntityAddress>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Direction Direction { get; set; }

        public ICollection<Certificate> Certificates { get; set; }
        public ICollection<DocumentInformation> DocumentInformations { get; set; }
        public ICollection<LegalEntityAddress> LegalEntityAddresses { get; set; }
    }
}
