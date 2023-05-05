using TeamTracker.Models;

namespace TeamTracker.Tests;

public class TestData
{
    public static List<Department> GetDepartments()
    {
        return new List<Department>
        {
            new Department
            {
                DepartmentID = 1,
                Name = "HR",
                Floor = 1
            },
            new Department
            {
                DepartmentID = 2,
                Name = "IT",
                Floor = 2
            },
            new Department
            {
                DepartmentID = 3,
                Name = "Marketing",
                Floor = 3
            }
        };
    }

    public static List<EmployeeViewModel> GetAllEmployees()
    {
        var random = new Random();
        var employees = new List<EmployeeViewModel>();

        for (int i = 1; i <= 10; i++)
        {
            var employee = new EmployeeViewModel
            {
                Name = $"Employee {i}",
                Surname = $"Surname {i}",
                Age = random.Next(22, 60),
                Gender = i % 2 == 0 ? "M" : "F",
                DepartmentID = random.Next(1, 4),
                DepartmentName = "IT",
                ProgrammingLanguageID = random.Next(1, 6),
                ProgrammingLanguageName = "C#"
            };

            employees.Add(employee);
        }

        return employees;
    }

    public static List<ProgrammingLanguage> GetProgrammingLanguages()
    {
        var programmingLanguage = new List<ProgrammingLanguage>();

        programmingLanguage.Add(new ProgrammingLanguage { Name = "C#" });
        programmingLanguage.Add(new ProgrammingLanguage { Name = "Java" });

        return programmingLanguage;
    }
}