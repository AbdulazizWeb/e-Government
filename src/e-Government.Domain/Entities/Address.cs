using e_Government.Domain.Entities.ForeignSection;
using e_Government.Domain.Entities.Legal;
using e_Government.Domain.Entities.PopulationSection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Government.Domain.Entities
{
    public class Address
    {        
        public int Id { get; set; }
        public string HomeName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int PostalCode { get; set; }
        public bool LastAddress { get; set; }
        public DateTime StartDateOfUse { get; set; }
        public DateTime EndDateOfUse { get; set; }


        public int IssuedByBranchId { get; set; }
        public int CustomsOfficeId { get; set; }
        public int PopulationId { get; set; }
        public int LegalEntityId { get; set; }

        public Population Population { get; set; }
        public IssuedByBranch IssuedByBranch { get; set; }
        public Customs CustomsOffice { get; set; }
        public LegalEntity LegalEntity { get; set; }
    }
}
