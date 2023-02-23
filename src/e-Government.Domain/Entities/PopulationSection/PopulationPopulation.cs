using e_Government.Domain.Enums;

namespace e_Government.Domain.Entities.PopulationSection
{
    public class PopulationPopulation
    {
        public int Id { get; set; }
        public int Population1Id { get; set; }
        public Relative Relative { get; set; }
        public int Population2Id { get; set; }

        public Population Population { get; set; }
    }
}
