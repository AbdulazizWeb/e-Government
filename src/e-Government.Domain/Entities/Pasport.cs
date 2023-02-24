namespace e_Government.Domain.Entities
{
    public class Pasport : DocumentInformation
    {
        public string SerialNumber { get; set; }
        public int PopulationId { get; set; }

        public Population Population { get; set; }
    }
}
