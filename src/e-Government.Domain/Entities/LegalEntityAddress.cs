namespace e_Government.Domain.Entities
{
    public class LegalEntityAddress : Address
    {
        public int LegalEntityId { get; set; }

        public LegalEntity LegalEntity { get; set; }
    }
}
