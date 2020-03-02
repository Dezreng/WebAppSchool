using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebAppSchool.Data;
using WebAppSchool.Models.CodeFirst;

namespace WebAppSchool.Controllers
{
    public class SheduleController : Controller
    {
        private readonly SchoolContext db;

        public SheduleController(SchoolContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var shedules = db.Shedules.Include(t => t.Teacher).Include(g => g.GroupClass).Include(s => s.Subject).ToList();

            return View(shedules);
        }

        public IActionResult Create()
        {
            ViewBag.Teachers = new SelectList(db.Teachers, "Id", "FioTeacher");
            ViewBag.Subjects = new SelectList(db.Subjects, "Id", "TitleSubject");
            ViewBag.GroupClasses = new SelectList(db.GroupClasses, "Id", "Letter");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Shedule shedule)
        {
            if (ModelState.IsValid)
            {
                db.Shedules.Add(shedule);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var shedule = db.Shedules.Find(id);

            if (shedule != null)
            {
                ViewBag.Teachers = new SelectList(db.Teachers, "Id", "FioTeacher", shedule.TeacherId);
                ViewBag.Subjects = new SelectList(db.Subjects, "Id", "TitleSubject", shedule.SubjectId);
                ViewBag.GroupClasses = new SelectList(db.GroupClasses, "Id", "Letter", shedule.GroupClassId);

                return View(shedule);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(Shedule shedule)
        {
            if (ModelState.IsValid)
            {
                db.Shedules.Update(shedule);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}