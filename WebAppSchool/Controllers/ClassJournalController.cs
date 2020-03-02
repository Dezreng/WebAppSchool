using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebAppSchool.Data;
using WebAppSchool.Models.CodeFirst;

namespace WebAppSchool.Controllers
{
    public class ClassJournalController : Controller
    {
        private readonly SchoolContext db;

        public ClassJournalController(SchoolContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var classJournals = db.ClassJournals.Include(st => st.Student).Include(su => su.Subject).ToList();
            return View(classJournals);
        }

        public IActionResult Create()
        {
            ViewBag.Students = new SelectList(db.Students, "Id", "FioStudent");
            ViewBag.Subjects = new SelectList(db.Subjects, "Id", "TitleSubject");

            return View();
        }

        [HttpPost]
        public IActionResult Create(ClassJournal classJournal)
        {
            if (ModelState.IsValid)
            {
                db.ClassJournals.Add(classJournal);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var classJournal = db.ClassJournals.Find(id);

            if (classJournal != null)
            {
                ViewBag.Students = new SelectList(db.Students, "Id", "FioStudent");
                ViewBag.Subjects = new SelectList(db.Subjects, "Id", "TitleSubject");

                return View(classJournal);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(ClassJournal classJournal)
        {
            if (ModelState.IsValid)
            {
                db.ClassJournals.Update(classJournal);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}