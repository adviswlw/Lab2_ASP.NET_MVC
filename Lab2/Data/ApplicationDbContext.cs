using Microsoft.EntityFrameworkCore;
using Lab2.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// сущности базы данных
    /// </summary>
    public DbSet<Hospital> Hospitals { get; set; }
    public DbSet<Patient> Patients { get; set; }
}
