using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebAppSchool.Data;
using WebAppSchool.Models.CodeFirst;
using X.PagedList;

namespace WebAppSchool.Controllers
{
    public class StudentController : Controller
    {
        private readonly SchoolContext db;

        public StudentController(SchoolContext context)
        {
            db = context;
        }

        public IActionResult Index(int? page, string searchFioStudent, string searchFioMother,
                                    string searchFioFather, string searchAddress)
        {
            int pageSize = 30;
            int pageNumber = (page ?? 1);

            ViewData["searchFioStudent"] = searchFioStudent;
            ViewData["searchFioMother"] = searchFioMother;
            ViewData["searchFioFather"] = searchFioFather;
            ViewData["searchAddress"] = searchAddress;

            IQueryable<Student> students = db.Students.Include(s => s.GroupClass);

            if (!String.IsNullOrEmpty(searchFioStudent))
            {
                students = students.Where(s => s.FioStudent.Contains(searchFioStudent));
            }
            if (!String.IsNullOrEmpty(searchFioMother))
            {
                students = students.Where(m => m.FioMother.Contains(searchFioMother));
            }
            if (!String.IsNullOrEmpty(searchFioFather))
            {
                students = students.Where(f => f.FioFather.Contains(searchFioFather));
            }
            if (!String.IsNullOrEmpty(searchAddress))
            {
                students = students.Where(a => a.Address.Contains(searchAddress));
            }

            students = students.OrderBy(i => i.Id);
            return View(students.ToPagedList(pageNumber, pageSize));
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
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Create));
        }

        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var student = db.Students.Find(id);
                ViewBag.GroupClasses = new SelectList(db.GroupClasses, "Id", "ClassRoomTeacher");

                return View(student);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Update(student);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(nameof(Edit));
        }

        public IActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var student = db.Students.Find(id);

                if (student != null)
                {
                    db.Students.Remove(student);
                    db.SaveChanges();
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
