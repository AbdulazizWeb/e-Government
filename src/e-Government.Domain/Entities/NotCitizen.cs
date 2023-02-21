using e_Government.Domain.Enums;

namespace e_Government.Domain.Entities
{
    public class NotCitizen
    {
        public int Id { get; set; } 
        public DateTime Birthday { get; set; }
        public string? FirstName { get; set; }
        public string? Lastname { get; set; }
        public string? MiddleName { get; set; }
        public Gender Gender { get; set; }
        public string? Nationality { get; set; }

    }
}
