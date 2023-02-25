using e_Government.Domain.Enums;

namespace e_Government.Domain.Entities
{
    public class PopulationFamily
    {
        public int Id { get; set; }
        public int Population1Id { get; set; }
        public Relative RelativeName { get; set; }
        public int Population2Id { get; set; }

        public Population Population1 { get; set; }
        public Population Population2 { get; set; }
    }
}
