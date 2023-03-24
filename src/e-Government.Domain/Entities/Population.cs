namespace e_Government.Domain.Entities
{
    public class Population : Person
    {
        public Population()
        {
            Pasports = new HashSet<Passport>();
            PopulationAddresses = new HashSet<PopulationAddress>();
            PopulationFamilies = new HashSet<PopulationFamily>();
            FamilyPopulation = new HashSet<PopulationFamily>();
            PopulationLegalEntities = new HashSet<PopulationLegalEntity>();
        }

        public DateOnly DiedDay { get; set; }

        public ICollection<Passport> Pasports { get; set; }
        public ICollection<PopulationAddress> PopulationAddresses { get; set; }
        public ICollection<PopulationFamily> PopulationFamilies { get; set; }
        public ICollection<PopulationFamily> FamilyPopulation { get; set; }
        public ICollection<PopulationLegalEntity> PopulationLegalEntities { get; set; }
    }
}
