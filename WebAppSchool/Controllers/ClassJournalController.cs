using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebAppSchool.Data;
using WebAppSchool.Models.CodeFirst;
using X.PagedList;

namespace WebAppSchool.Controllers
{
    public class ClassJournalController : Controller
    {
        private readonly SchoolContext db;

        public ClassJournalController(SchoolContext context)
        {
            db = context;
        }

        public IActionResult Index(int? page, DateTime? searchDate, string searchSubject, string searchStudent)
        {
            int pageSize = 30;
            int pageNumber = (page ?? 1);

            ViewData["searchDate"] = searchDate;
            ViewData["searchSubject"] = searchSubject;
            ViewData["searchStudent"] = searchStudent;

            IQueryable<ClassJournal> classJournals = db.ClassJournals.Include(st => st.Student).Include(su => su.Subject);

            if (searchDate.HasValue)
            {
                classJournals = classJournals.Where(d => d.Date == searchDate);
            }
            if (!String.IsNullOrEmpty(searchSubject))
            {
                classJournals = classJournals.Where(s => s.Subject.TitleSubject.Contains(searchSubject));
            }
            if (!String.IsNullOrEmpty(searchStudent))
            {
                classJournals = classJournals.Where(s => s.Student.FioStudent.Contains(searchStudent));
            }

            classJournals = classJournals.OrderBy(i => i.Id);
            return View(classJournals.ToPagedList(pageNumber, pageSize));
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

        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var classJournal = db.ClassJournals.Find(id);

                if (classJournal != null)
                {
                    ViewBag.Students = new SelectList(db.Students, "Id", "FioStudent");
                    ViewBag.Subjects = new SelectList(db.Subjects, "Id", "TitleSubject");

                    return View(classJournal);
                }
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

        public IActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var classJournal = db.ClassJournals.Find(id);

                if (classJournal != null)
                {
                    db.ClassJournals.Remove(classJournal);
                    db.SaveChanges();
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}