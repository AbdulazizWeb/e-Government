namespace e_Government.Domain.Entities
{
    public class PopulationLegalEntity
    {
        public int Id { get; set; }
        public int PopulationId { get; set; }
        public int LegalEntityId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Population Population { get; set; }
        public LegalEntity LegalEntity { get; set; }
    }
}
