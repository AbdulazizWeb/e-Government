using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Government.Domain.Entities.Legal
{
    public class Certificate
    {
        public string SerialNumber { get; set; }
        public int LegalEntityId { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime ValidityPeriod { get; set; }
        public bool Validity { get; set; }
        public int IssuedByBranchId { get; set; }

        public LegalEntity LegalEntity { get; set; }
        public IssuedByBranch IssuedByBranch { get; set; }
    }
}