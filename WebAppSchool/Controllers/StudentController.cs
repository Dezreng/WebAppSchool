using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebAppSchool.Data;
using WebAppSchool.Models.CodeFirst;

namespace WebAppSchool.Controllers
{
    public class StudentController : Controller
    {
        private readonly SchoolContext db;

        public StudentController(SchoolContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var students = db.Students.Include(s => s.GroupClass).ToList();
            return View(students);
        }

        public IActionResult Create()
        {
            ViewBag.GroupClasses = new SelectList(db.GroupClasses, "Id", "ClassRoomTeacher");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Create");
        }

        public IActionResult Edit(int id)
        {
            var student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewBag.GroupClasses = new SelectList(db.GroupClasses, "Id", "ClassRoomTeacher");
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {

            if (ModelState.IsValid)
            {
                db.Students.Update(student);
                return RedirectToAction("Index");
            }

            return View("Edit");
        }
    }
}
