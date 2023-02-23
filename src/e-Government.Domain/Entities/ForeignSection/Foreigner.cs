using e_Government.Domain.Enums;

namespace e_Government.Domain.Entities.ForeignSection
{
    public class Foreigner
    {
        public Foreigner()
        {
            Visas = new HashSet<Visa>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Midlname { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public Nationality Nationality { get; set; }

        public ICollection<Visa> Visas { get; set; }

    }
}
