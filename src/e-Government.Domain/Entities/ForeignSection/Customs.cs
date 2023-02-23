namespace e_Government.Domain.Entities.ForeignSection
{
    public class Customs
    {
        public Customs()
        {
            Visas = new HashSet<Visa>();
            Addresses = new HashSet<Address>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Visa> Visas { get; set; }
        public ICollection<Address> Addresses { get; set; }

    }
}
