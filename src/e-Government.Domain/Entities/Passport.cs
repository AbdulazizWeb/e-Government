namespace e_Government.Domain.Entities
{
    public class Passport : Document
    {
        public int PopulationId { get; set; }

        public Population Population { get; set; }
    }
}
