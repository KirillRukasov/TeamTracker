using TeamTracker.Models;

namespace TeamTracker.Data.Repositories;

public interface IEmployeeRepository
{
    IEnumerable<EmployeeViewModel> GetAllEmployees();
    EmployeeViewModel GetEmployeeById(int employeeId);
    void AddEmployee(Employee employee);
    void UpdateEmployee(Employee employee);
    void DeleteEmployee(int employeeId);
}