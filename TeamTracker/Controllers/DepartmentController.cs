using Microsoft.AspNetCore.Mvc;
using TeamTracker.Data.Repositories;
using TeamTracker.Models;

namespace TeamTracker.Controllers;

public class DepartmentController : Controller
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentController(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }
    
            // GET: Department
        public IActionResult Index()
        {
            var departments = _departmentRepository.GetDepartments();
            return View(departments.ToList());
        }

        // GET: Department/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Floor")]Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.AddDepartment(department);
                return RedirectToAction(nameof(Index));
            }

            return View(department);
        }

        // GET: Department/Edit/5
        public IActionResult Edit(int id)
        {
            var department = _departmentRepository.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Department/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Department department)
        {
            if (ModelState.IsValid)
            {
                _departmentRepository.UpdateDepartment(department);
                return RedirectToAction(nameof(Index));
            }

            return View(department);
        }

        // GET: Department/Delete/5
        public IActionResult Delete(int id)
        {
            var department = _departmentRepository.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Department/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _departmentRepository.DeleteDepartment(id);
            return RedirectToAction(nameof(Index));
        }
}