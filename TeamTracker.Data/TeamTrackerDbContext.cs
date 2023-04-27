using Microsoft.EntityFrameworkCore;
using TeamTracker.Models;

namespace TeamTracker.Data;

public class TeamTrackerDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }

    public TeamTrackerDbContext(DbContextOptions<TeamTrackerDbContext> options) : base(options)
    {
        
    }
}