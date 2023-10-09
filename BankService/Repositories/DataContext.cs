using BankService.Models;
using Microsoft.EntityFrameworkCore;

namespace BankService;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<Client> Clients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>()
            .HasIndex(p => new { p.Number })
            .IsUnique();
        modelBuilder.Entity<Card>()
            .HasIndex(p => new { p.Number })
            .IsUnique();
        modelBuilder.Entity<Client>()
            .HasIndex(p => new { p.Id })
            .IsUnique();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost; Port=5432;Database=Bank;User Id=postgres;Password=root");
    }
}