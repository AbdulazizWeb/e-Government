using e_Government.Domain.Enums;

namespace e_Government.Domain.Entities
{
    public class Document
    {
        public int Id { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime ValidityPeriod { get; set; }
        public DateTime StoppedDate { get; set; }
        public bool IsValidity { get; set; }
        public bool IsLast { get; set; }

        public BelongsCountryName BelongsCountryName { get; set; }
        public string SerialNumber { get; set; }
    }
}
