using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebAppSchool.Data;
using WebAppSchool.Models.CodeFirst;

namespace WebAppSchool.Controllers
{
    public class TeacherController : Controller
    {
        private readonly SchoolContext db;

        public TeacherController(SchoolContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var teachers = db.Teachers.Include(p => p.Position).ToList();

            return View(teachers);
        }

        public IActionResult Create()
        {
            ViewBag.Positions = new SelectList(db.Positions, "Id", "TitlePosition");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Teachers.Add(teacher);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var teacher = db.Teachers.Find(id);
            ViewBag.Positions = new SelectList(db.Positions, "Id", "TitlePosition");

            return View(teacher);
        }

        [HttpPost]
        public IActionResult Edit(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Teachers.Update(teacher);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}