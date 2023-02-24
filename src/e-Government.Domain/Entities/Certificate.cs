namespace e_Government.Domain.Entities
{
    public class Certificate : DocumentInformation
    {
        public string SerialNumber { get; set; }
        public int LegalEntityId { get; set; }

        public LegalEntity LegalEntity { get; set; }
    }
}
