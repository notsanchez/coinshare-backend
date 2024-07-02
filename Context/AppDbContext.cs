using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Companie> Companies { get; set; }
    public DbSet<UserCompanie> UsersCompanies { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
}
