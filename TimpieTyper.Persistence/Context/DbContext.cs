using Microsoft.EntityFrameworkCore;
using TimpieTyper.Persistence.Entities;

namespace TimpieTyper.Persistence.Context;

public class AppDbContext : DbContext
{
    private readonly string _connectionString;

    public AppDbContext(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public DbSet<WordEntity> Words { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));
        }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WordEntity>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }

}