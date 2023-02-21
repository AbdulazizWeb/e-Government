using e_Government.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_Government.Application.Abstractions
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Citizen> Citizens { get; set; }
        DbSet<NotCitizen> NotCitizens { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
