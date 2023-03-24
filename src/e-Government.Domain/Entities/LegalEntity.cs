using e_Government.Domain.Enums;

namespace e_Government.Domain.Entities
{
    public class LegalEntity
    {
        public LegalEntity()
        {
            Certificates = new HashSet<Certificate>();
            LegalEntityAddresses = new HashSet<LegalEntityAddress>();
            LegalEntityPopulation = new HashSet<PopulationLegalEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Direction Direction { get; set; }

        public ICollection<Certificate> Certificates { get; set; }
        public ICollection<LegalEntityAddress> LegalEntityAddresses { get; set; }
        public ICollection<PopulationLegalEntity> LegalEntityPopulation { get; set; }
    }
}
