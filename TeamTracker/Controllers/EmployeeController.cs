using Microsoft.AspNetCore.Mvc;
using TeamTracker.Data.Repositories;
using TeamTracker.Models;

namespace TeamTracker.Controllers;

public class EmployeeController : Controller
{
    private readonly IEmployeeRepository _employeeRepository;
    private IDepartmentRepository _departmentRepository;
    private IProgrammingLanguageRepository _programmingLanguageRepository;

    public EmployeeController(IEmployeeRepository employeeRepository,
        IProgrammingLanguageRepository programmingLanguageRepository, IDepartmentRepository departmentRepository)
    {
        _employeeRepository = employeeRepository;
        _programmingLanguageRepository = programmingLanguageRepository;
        _departmentRepository = departmentRepository;
    }

    // GET: Employee
    public IActionResult Index()
    {
        var employees = _employeeRepository.GetAllEmployees();
        return View(employees.ToList());
    }

    // GET: Employee/Create
    public IActionResult Create()
    {
        EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel
        {
            Employee = new Employee(),
            Departments = _departmentRepository.GetDepartments(),
            ProgrammingLanguages = _programmingLanguageRepository.GetProgrammingLanguages()
        };

        return View(employeeEditViewModel);
    }

    // POST: Employee/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Employee employee)
    {
        if (ModelState.IsValid)
        {
            _employeeRepository.AddEmployee(employee);
            return RedirectToAction(nameof(Index));
        }

        EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel
        {
            Employee = employee,
            Departments = _departmentRepository.GetDepartments(),
            ProgrammingLanguages = _programmingLanguageRepository.GetProgrammingLanguages()
        };
        return View(employeeEditViewModel);
    }

    //GET: Employee/Edit/5
    public IActionResult Edit(int id)
    {
        var employeeViewModel = _employeeRepository.GetEmployeeById(id);
        if (employeeViewModel == null)
        {
            return NotFound();
        }

        Employee employee = new Employee
        {
            EmployeeID = employeeViewModel.EmployeeID,
            Name = employeeViewModel.Name,
            Surname = employeeViewModel.Surname,
            Age = employeeViewModel.Age,
            Gender = employeeViewModel.Gender,
            DepartmentID = employeeViewModel.DepartmentID,
            ProgrammingLanguageID = employeeViewModel.ProgrammingLanguageID
        };

        var model = new EmployeeEditViewModel
        {
            Employee = employee,
            Departments = _departmentRepository.GetDepartments(),
            ProgrammingLanguages = _programmingLanguageRepository.GetProgrammingLanguages()
        };

        return View(model);
    }

    // POST: Employee/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Employee employee)
    {
        if (ModelState.IsValid)
        {
            _employeeRepository.UpdateEmployee(employee);
            return RedirectToAction(nameof(Index));
        }
        
        var model = new EmployeeEditViewModel
        {
            Employee = employee,
            Departments = _departmentRepository.GetDepartments(),
            ProgrammingLanguages = _programmingLanguageRepository.GetProgrammingLanguages()
        };
        return View(model);
    }
    
    // GET: Employee/Delete/5
    public IActionResult Delete(int id)
    {
        var employee = _employeeRepository.GetEmployeeById(id);
        if (employee == null)
        {
            return NotFound();
        }

        return View(employee);
    }

    // POST: Employee/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        _employeeRepository.DeleteEmployee(id);
        return RedirectToAction(nameof(Index));
    }
}