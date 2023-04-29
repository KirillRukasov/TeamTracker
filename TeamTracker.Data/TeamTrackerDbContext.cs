using Microsoft.EntityFrameworkCore;
using TeamTracker.Models;

namespace TeamTracker.Data;

public class TeamTrackerDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
    public DbSet<EmployeeViewModel> EmployeeViewModels { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeViewModel>().HasNoKey().ToView(null);
    }
    public TeamTrackerDbContext(DbContextOptions<TeamTrackerDbContext> options) : base(options)
    {
        
    }
}