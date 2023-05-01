using Microsoft.AspNetCore.Mvc;
using TeamTracker.Data.Repositories;
using TeamTracker.Models;

namespace TeamTracker.Controllers;

public class ProgrammingLanguageController : Controller
{
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

    public ProgrammingLanguageController(IProgrammingLanguageRepository programmingLanguageRepository)
    {
        _programmingLanguageRepository = programmingLanguageRepository;
    }
    
            // GET: ProgrammingLanguage
        public IActionResult Index()
        {
            var programmingLanguages = _programmingLanguageRepository.GetProgrammingLanguages();
            return View(programmingLanguages.ToList());
        }
        
        // GET: ProgrammingLanguage/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProgrammingLanguage/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProgrammingLanguage programmingLanguage)
        {
            if (ModelState.IsValid)
            {
                _programmingLanguageRepository.AddProgrammingLanguage(programmingLanguage);
                return RedirectToAction(nameof(Index));
            }

            return View(programmingLanguage);
        }

        // GET: ProgrammingLanguage/Edit/5
        public IActionResult Edit(int id)
        {
            var programmingLanguage = _programmingLanguageRepository.GetProgrammingLanguageById(id);
            if (programmingLanguage == null)
            {
                return NotFound();
            }

            return View(programmingLanguage);
        }

        // POST: ProgrammingLanguage/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProgrammingLanguage programmingLanguage)
        {
            if (ModelState.IsValid)
            {
                _programmingLanguageRepository.UpdateProgrammingLanguage(programmingLanguage);
                return RedirectToAction(nameof(Index));
            }

            return View(programmingLanguage);
        }

        // GET: ProgrammingLanguage/Delete/5
        public IActionResult Delete(int id)
        {
            var programmingLanguage = _programmingLanguageRepository.GetProgrammingLanguageById(id);
            if (programmingLanguage == null)
            {
                return NotFound();
            }

            return View(programmingLanguage);
        }

        // POST: ProgrammingLanguage/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _programmingLanguageRepository.DeleteProgrammingLanguage(id);
            return RedirectToAction(nameof(Index));
        }
}