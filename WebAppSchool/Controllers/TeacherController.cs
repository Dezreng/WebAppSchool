using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAppSchool.Data;
using WebAppSchool.Models.CodeFirst;
using X.PagedList;

namespace WebAppSchool.Controllers
{
    public class TeacherController : Controller
    {
        private readonly SchoolContext db;

        public TeacherController(SchoolContext context)
        {
            db = context;
        }

        public IActionResult Index(int? page, string searchFio, string searchTelephone, string searchPosition)
        {
            ViewData["searchFio"] = searchFio;
            ViewData["searchTelephone"] = searchTelephone;
            ViewData["searchPosition"] = searchPosition;

            int pageSize = 30;
            int pageNumber = (page ?? 1);

            IQueryable<Teacher> teachers = db.Teachers.Include(p=>p.Position);

            if (!String.IsNullOrEmpty(searchFio))
            {
                teachers = teachers.Where(f => f.FioTeacher.Contains(searchFio));
            }
            if (!String.IsNullOrEmpty(searchTelephone))
            {
                teachers = teachers.Where(t => t.Telephone.Contains(searchTelephone));
            }
            if (!String.IsNullOrEmpty(searchPosition))
            {
                teachers = teachers.Where(p => p.Position.TitlePosition.Contains(searchPosition));
            }

            teachers = teachers.OrderBy(i => i.Id);

            return View(teachers.ToPagedList(pageNumber, pageSize));
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

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var teacher = db.Teachers.Find(id);
                ViewBag.Positions = new SelectList(db.Positions, "Id", "TitlePosition");

                return View(teacher);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Teachers.Update(teacher);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var teacher = db.Teachers.Find(id);

                if (teacher != null)
                {

                    db.Teachers.Remove(teacher);
                    db.SaveChanges();
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}