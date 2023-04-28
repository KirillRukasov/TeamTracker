using Microsoft.AspNetCore.Mvc;
using TeamTracker.Data.Repositories;
using TeamTracker.Models;

namespace TeamTracker.Controllers;

public class TestController : Controller
{
            private readonly IDepartmentRepository _departmentRepository;
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public TestController(IDepartmentRepository departmentRepository, IProgrammingLanguageRepository programmingLanguageRepository, IEmployeeRepository employeeRepository)
        {
            _departmentRepository = departmentRepository;
            _programmingLanguageRepository = programmingLanguageRepository;
            _employeeRepository = employeeRepository;
        }

        public IActionResult InitializeData()
        {
            // Add departments
            _departmentRepository.AddDepartment(new Department { Name = "HR", Floor = 1 });
            _departmentRepository.AddDepartment(new Department { Name = "IT", Floor = 2 });
            _departmentRepository.AddDepartment(new Department { Name = "Marketing", Floor = 3 });

            // Add programming languages
            _programmingLanguageRepository.AddProgrammingLanguage(new ProgrammingLanguage { Name = "C#" });
            _programmingLanguageRepository.AddProgrammingLanguage(new ProgrammingLanguage { Name = "Java" });
            _programmingLanguageRepository.AddProgrammingLanguage(new ProgrammingLanguage { Name = "Python" });
            _programmingLanguageRepository.AddProgrammingLanguage(new ProgrammingLanguage { Name = "JavaScript" });
            _programmingLanguageRepository.AddProgrammingLanguage(new ProgrammingLanguage { Name = "Ruby" });

            // Add employees
            var random = new Random();
            for (int i = 1; i <= 10; i++)
            {
                _employeeRepository.AddEmployee(new Employee
                {
                    Name = $"Employee {i}",
                    Surname = $"Surname {i}",
                    Age = random.Next(22, 60),
                    Gender = i % 2 == 0 ? "M" : "F",
                    DepartmentID = random.Next(1, 4),
                    ProgrammingLanguageID = random.Next(1, 6)
                });
            }

            return Content("Data has been initialized successfully.");
        }
}