using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Government.Domain.Entities.ForeignSection
{
    public class Visa
    {
        public int Id { get; set; }
        public int ForeignerId { get; set; }
        public string Number { get; set; }
        public DateTime DateOfIssue { get; set; }
        public int CustomsId { get; set; }
        public bool LastVisa { get; set; }
        public DateTime ValidityPerriod { get; set; }
        public bool Validity { get; set; }

        public Foreigner Foreigner { get; set; }
        public Customs Customs { get; set; }
    }
}
