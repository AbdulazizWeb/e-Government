namespace e_Government.Domain.Entities
{
    public class PopulationAddress : Address
    {
        public int PopulationId { get; set; }

        public Population Population { get; set; }
    }
}
