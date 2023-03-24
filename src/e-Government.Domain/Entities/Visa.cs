namespace e_Government.Domain.Entities
{
    public class Visa : Document
    {
        public int ForeignerId { get; set; }

        public Foreigner Foreigner { get; set; }
    }
}
