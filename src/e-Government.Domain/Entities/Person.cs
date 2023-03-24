using e_Government.Domain.Enums;
using Microsoft.VisualBasic;

namespace e_Government.Domain.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MidleName { get; set; }
        public Nationality NationalityName { get; set; }
        public Gender Gender { get; set; }
        public DateOnly Birthday { get; set; }
    }
}