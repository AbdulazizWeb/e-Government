namespace e_Government.Domain.Entities
{
    public class Certificate : Document
    {
        public int LegalEntityId { get; set; }

        public LegalEntity LegalEntity { get; set; }
    }
}
