using Microsoft.EntityFrameworkCore;
using ClubMembershipApplication.Models;

namespace ClubMembershipApplication.Data;

public class ClubMembershipDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}ClubMembership.db");
        base.OnConfiguring(optionsBuilder);
    }
    
    public DbSet<User> Users { get; set; }
}