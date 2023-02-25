namespace e_Government.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public int AddressIdFromCadastre { get; set; }
        public bool IsLastAddress { get; set; }
        public DateTime StartDateOfUse { get; set; }
        public DateTime EndDateOfUse { get; set; }
    }
}
