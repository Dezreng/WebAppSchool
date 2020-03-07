using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebAppSchool.Data;
using WebAppSchool.Models.CodeFirst;
using X.PagedList;

namespace WebAppSchool.Controllers
{
    public class SubjectController : Controller
    {
        private readonly SchoolContext db;

        public SubjectController(SchoolContext context)
        {
            db = context;
        }

        public IActionResult Index(int? page, string searchTitle)
        {
            int pageSize = 30;
            int pageNumber = (page ?? 1);
            ViewData["searchTitle"] = searchTitle;

            IQueryable<Subject> subjects = db.Subjects;

            if (!String.IsNullOrEmpty(searchTitle))
            {
                subjects = subjects.Where(t => t.TitleSubject.Contains(searchTitle));
            }

            return View(subjects.ToPagedList(pageNumber, pageSize));
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

        public IActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var subject = db.Subjects.Find(id);

                if (subject != null)
                {
                    db.Subjects.Remove(subject);
                    db.SaveChanges();
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}