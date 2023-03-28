using DBProject.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DBProject.Contexts;

internal class DataContext : DbContext
{
    private readonly string _connectionString = @"";

    #region constructors
    public DataContext()
    { 
    }

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    #endregion

    #region overrides
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer(_connectionString);
    }

    #endregion


    public DbSet<TicketEntity> Tickets { get; set; } = null!;
    public DbSet<CustomerEntity> Customers { get; set; }


}
