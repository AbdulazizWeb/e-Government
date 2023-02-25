namespace e_Government.Domain.Entities
{
    public class Foreigner : Person
    {
        public Foreigner()
        {
            Visas = new HashSet<Visa>();
        }

        public ICollection<Visa> Visas { get; set; }
    }
}
