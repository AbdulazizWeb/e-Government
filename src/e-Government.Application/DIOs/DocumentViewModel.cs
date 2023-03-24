using e_Government.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Government.Application.DIOs
{
    public class DocumentViewModel
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public DateTime DateOfIssue { get; set; }
        public DateTime ValidityPeriod { get; set; }
        public DateTime StoppedDate { get; set; }
        public bool IsValidity { get; set; }
        public bool IsLast { get; set; }

        public BelongsCountryName BelongsCountryName { get; set; }
    }
}
