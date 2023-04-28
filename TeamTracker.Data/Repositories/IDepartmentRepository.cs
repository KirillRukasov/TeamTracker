using TeamTracker.Models;

namespace TeamTracker.Data.Repositories;

public interface IDepartmentRepository
{
    IEnumerable<Department> GetDepartments();
    Department GetDepartmentById(int departmentId);
    void AddDepartment(Department department);
    void UpdateDepartment(Department department);
    void DeleteDepartment(int departmentId);
}