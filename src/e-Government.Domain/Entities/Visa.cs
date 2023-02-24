namespace e_Government.Domain.Entities
{
    public class Visa : DocumentInformation
    {
        public string SerialNumber { get; set; }
        public int ForeignerId { get; set; }

        public Foreigner Foreigner { get; set; }
    }
}
