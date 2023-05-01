using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TeamTracker.Models;

namespace TeamTracker.Data.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly TeamTrackerDbContext _dbContext;

    public EmployeeRepository(TeamTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<EmployeeViewModel> GetAllEmployees()
    {
        return _dbContext.EmployeeViewModels.FromSqlRaw("EXECUTE GetAllEmployees")
            .AsNoTracking()
            .ToList();
    }

    public EmployeeViewModel GetEmployeeById(int employeeId)
    {
        return _dbContext.EmployeeViewModels.FromSqlRaw("EXECUTE GetEmployeeById @EmployeeID", new SqlParameter("@EmployeeID", employeeId))
            .AsNoTracking().AsEnumerable()
            .FirstOrDefault();
    }

    public void AddEmployee(Employee employee)
    {
        _dbContext.Database.ExecuteSqlRaw("EXECUTE AddEmployee @Name, @Surname, @Age, @Gender, @DepartmentID, @ProgrammingLanguageID",
            new SqlParameter("@Name", employee.Name),
            new SqlParameter("@Surname", employee.Surname),
            new SqlParameter("@Age", employee.Age),
            new SqlParameter("@Gender", employee.Gender),
            new SqlParameter("@DepartmentID", employee.DepartmentID),
            new SqlParameter("@ProgrammingLanguageID", employee.ProgrammingLanguageID));
    }

    public void UpdateEmployee(Employee employee)
    {
        var parameters = new[]
        {
                new SqlParameter("@EmployeeID", employee.EmployeeID),
                new SqlParameter("@Name", employee.Name),
                new SqlParameter("@Surname", employee.Surname),
                new SqlParameter("@Age", employee.Age),
                new SqlParameter("@Gender", employee.Gender),
                new SqlParameter("@DepartmentID", employee.DepartmentID),
                new SqlParameter("@ProgrammingLanguageID", employee.ProgrammingLanguageID)
            };
        _dbContext.Database.ExecuteSqlRaw("EXECUTE UpdateEmployee @EmployeeID, @Name, @Surname, @Age, @Gender, @DepartmentID, @ProgrammingLanguageID", parameters);
        Console.WriteLine("UpdateEmployee called for EmployeeID: {0}", employee.EmployeeID);

    }

    public void DeleteEmployee(int employeeId)
    {
        _dbContext.Database.ExecuteSqlRaw("EXECUTE DeleteEmployee @EmployeeID", new SqlParameter("@EmployeeID", employeeId));
    }
}