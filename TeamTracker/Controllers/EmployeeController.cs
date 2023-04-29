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

        // GET: Employee/Details/5
        public IActionResult Details(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
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

            return View(employee);
        }

        //GET: Employee/Edit/5
        public IActionResult Edit(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            
            ViewBag.Departments = _departmentRepository.GetDepartments();
            ViewBag.ProgrammingLanguages = _programmingLanguageRepository.GetProgrammingLanguages();
        
            return View(employee);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EmployeeViewModel  employeeViewModel)
        {
            if (id != employeeViewModel.EmployeeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
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

                _employeeRepository.UpdateEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            
            ViewBag.Departments = _departmentRepository.GetDepartments();
            ViewBag.ProgrammingLanguages = _programmingLanguageRepository.GetProgrammingLanguages();
            return View(employeeViewModel);
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