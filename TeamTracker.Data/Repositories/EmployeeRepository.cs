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

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _dbContext.Employees.FromSqlRaw("EXECUTE GetAllEmployees")
                .Include(e => e.Department)
                .Include(e => e.ProgrammingLanguage)
                .ToList();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return _dbContext.Employees.FromSqlRaw("EXECUTE GetEmployeeById @EmployeeID", new SqlParameter("@EmployeeID", employeeId))
                .Include(e => e.Department)
                .Include(e => e.ProgrammingLanguage)
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
            _dbContext.Database.ExecuteSqlRaw("EXECUTE UpdateEmployee @EmployeeID, @Name, @Surname, @Age, @Gender, @DepartmentID, @ProgrammingLanguageID",
                new SqlParameter("@EmployeeID", employee.EmployeeID),
                new SqlParameter("@Name", employee.Name),
                new SqlParameter("@Surname", employee.Surname),
                new SqlParameter("@Age", employee.Age),
                new SqlParameter("@Gender", employee.Gender),
                new SqlParameter("@DepartmentID", employee.DepartmentID),
                new SqlParameter("@ProgrammingLanguageID", employee.ProgrammingLanguageID));
        }

        public void DeleteEmployee(int employeeId)
        {
            _dbContext.Database.ExecuteSqlRaw("EXECUTE DeleteEmployee @EmployeeID", new SqlParameter("@EmployeeID", employeeId));
        }
}