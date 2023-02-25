namespace e_Government.Domain.Entities
{
    public class Population : Person
    {
        public Population()
        {
            Pasports = new HashSet<Pasport>();
            PopulationAddresses = new HashSet<PopulationAddress>();
            PopulationFamilies = new HashSet<PopulationFamily>();
            FamilyPopulation = new HashSet<PopulationFamily>();
        }

        public DateTime DiedDay { get; set; }

        public ICollection<Pasport> Pasports { get; set; }
        public ICollection<PopulationAddress> PopulationAddresses { get; set; }
        public ICollection<PopulationFamily> PopulationFamilies { get; set; }
        public ICollection<PopulationFamily> FamilyPopulation { get; set; }
    }
}
