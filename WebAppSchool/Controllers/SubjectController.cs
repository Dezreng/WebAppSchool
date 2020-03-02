using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebAppSchool.Data;
using WebAppSchool.Models.CodeFirst;

namespace WebAppSchool.Controllers
{
    public class SubjectController : Controller
    {
        private readonly SchoolContext db;

        public SubjectController(SchoolContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var subjects = db.Subjects.ToList();
            return View(subjects);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Subjects.Add(subject);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var subject = db.Subjects.Find(id);

            if (subject != null)
            {
                return View(subject);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Subjects.Update(subject);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}