using Microsoft.EntityFrameworkCore;
using ResTIConnect.Domain.Entities;

namespace ResTIConnect.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
    public DbSet<User> Users { get; set; }
}
