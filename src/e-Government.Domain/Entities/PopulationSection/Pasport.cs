using e_Government.Domain.Entities.Legal;
using e_Government.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Government.Domain.Entities.PopulationSection
{
    public class Pasport
    {
        public string SerialNumber { get; set; }
        public int PopulationId { get; set; }
        public string PINFLNumber { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime ValidityPeriod { get; set; }        
        public bool Validity { get; set; }
        public int IssuedByBranchId { get; set; }
        public bool Citizenship { get; set; }

        public CountryNameCitizenship countryNameCitizenship { get; set; }        
        public Population Population { get; set; }
        public IssuedByBranch IssuedByBranch { get; set; }
    }
}
