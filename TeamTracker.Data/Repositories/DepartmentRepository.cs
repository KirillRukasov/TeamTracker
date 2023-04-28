using Microsoft.Data.SqlClient;
using TeamTracker.Models;
using Microsoft.EntityFrameworkCore;


namespace TeamTracker.Data.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly TeamTrackerDbContext _dbContext;

    public DepartmentRepository(TeamTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Department> GetDepartments()
    {
        return _dbContext.Departments.FromSqlRaw("EXECUTE GetDepartments").ToList();
    }

    public Department GetDepartmentById(int departmentId)
    {
        return _dbContext.Departments.FromSqlRaw("EXECUTE GetDepartmentByID @DepartmentID", new SqlParameter("@DepartmentID", departmentId))
            .FirstOrDefault();
    }

    public void AddDepartment(Department department)
    {
        _dbContext.Database.ExecuteSqlRaw("EXECUTE AddDepartment @Name, @Floor", 
            new SqlParameter("@Name", department.Name), new SqlParameter("@Floor", department.Floor));
    }

    public void UpdateDepartment(Department department)
    {
        _dbContext.Database.ExecuteSqlRaw("EXECUTE UpdateDepartment @DepartmentID, @Name, @Floor", 
            new SqlParameter("@DepartmentID", department.DepartmentID), new SqlParameter("@Name", department.Name), 
            new SqlParameter("@Floor", department.Floor));
    }

    public void DeleteDepartment(int departmentId)
    {
        _dbContext.Database.ExecuteSqlRaw("EXECUTE DeleteDepartmentByID @DepartmentID", new SqlParameter("@DepartmentID", departmentId));
    }
}