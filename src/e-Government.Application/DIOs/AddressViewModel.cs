using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Government.Application.DIOs
{
    public class AddressViewModel
    {
        public int Id { get; set; }
        public string BuildingNumber { get; set; }
        public string StreetName { get; set; }
        public string CityName { get; set; }
        public bool IsLastAddress { get; set; }
        public DateTime StartDateOfUse { get; set; }
        public DateTime EndDateOfUse { get; set; }
    }
}
