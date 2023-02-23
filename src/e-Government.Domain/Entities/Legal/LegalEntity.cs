using e_Government.Domain.Enums;

namespace e_Government.Domain.Entities.Legal
{
    public class LegalEntity
    {
        public LegalEntity()
        {
            Certificates = new HashSet<Certificate>();
            Addresses = new HashSet<Address>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public Direction Direction { get; set; }

        public ICollection<Certificate> Certificates { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
}
