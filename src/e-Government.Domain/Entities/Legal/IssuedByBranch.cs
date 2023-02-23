using e_Government.Domain.Entities.PopulationSection;

namespace e_Government.Domain.Entities.Legal
{
    public class IssuedByBranch
    {
        public IssuedByBranch()
        {
            Pasports = new HashSet<Pasport>();
            Certificates = new HashSet<Certificate>();
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Certificate> Certificates { get; set; }
        public ICollection<Pasport> Pasports { get; set; }
        public ICollection<Address> Addresses { get; set; }

    }
}
