using e_Government.Domain.Enums;

namespace e_Government.Domain.Entities
{
    public class DocumentInformation
    {
        public int Id { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime ValidityPeriod { get; set; }
        public bool IsValidity { get; set; }
        public bool IsLast { get; set; }
        public int IssuedByBranchLegalEntityId { get; set; }
        public BelongsCountryName BelongsCountryName { get; set; }

        public LegalEntity IssuedByBranchLegalEntity { get; set; }
    }
}
