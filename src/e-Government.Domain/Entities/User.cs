using e_Government.Domain.Enums;

namespace e_Government.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? PasswordHash { get; set; }
        public UserRole Role { get; set; }
    }
}
