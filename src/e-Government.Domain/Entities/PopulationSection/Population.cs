using e_Government.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Government.Domain.Entities.PopulationSection
{
    public class Population
    {
        public Population()
        {
            Pasports = new HashSet<Pasport>();
            PopuletionPopulations = new HashSet<PopulationPopulation>();
            Addresses = new HashSet<Address>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MidleName { get; set; }
        public DateTime Birthday { get; set; }
        public Nationality Nationality { get; set; }
        public Gender Gender { get; set; }
        public DateTime DiedDay { get; set; }

        public ICollection<Pasport> Pasports { get; set; }
        public ICollection<PopulationPopulation> PopuletionPopulations { get; set; }
        public ICollection<Address> Addresses { get; set; }

    }
}
