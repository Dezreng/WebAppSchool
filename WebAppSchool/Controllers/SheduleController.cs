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
    public class SheduleController : Controller
    {
        private readonly SchoolContext db;

        public SheduleController(SchoolContext context)
        {
            db = context;
        }

        public IActionResult Index(int? page, DateTime? searchDate, int? searchClass, bool searchTeacher)
        {
            int pageSize = 30;
            int pageNumber = (page ?? 1);
            ViewData["searchDate"] = searchDate;
            ViewData["searchClass"] = searchClass;
            ViewData["searchTeacher"] = searchTeacher;

            IQueryable<Shedule> shedules = db.Shedules.Include(t => t.Teacher).Include(g => g.GroupClass).Include(s => s.Subject);

            if (searchDate.HasValue)
            {
                shedules = shedules.Where(d => d.Date == searchDate);
            }
            if (searchClass.HasValue && searchClass != 0)
            {
                shedules = shedules.Where(g => g.GroupClassId == searchClass);
            }
            if (searchTeacher)
            {
                shedules = shedules.Where(t => t.Teacher.FioTeacher.Split(new char[] { ' ' })[0].Length <= 6); ;
            }

            List<SelectListItem> selectListItems = new SelectList(db.GroupClasses.Select(s => new
            {
                Id = s.Id,
                Class = s.YearStudy + s.Letter
            }), "Id", "Class").ToList();

            selectListItems.Insert(0, new SelectListItem { Value = "0", Text = "Все" });
            ViewBag.GroupClasses = selectListItems;

            shedules = shedules.OrderBy(i => i.Id);

            return View(shedules.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult Create()
        {
            ViewBag.Teachers = new SelectList(db.Teachers, "Id", "FioTeacher");
            ViewBag.Subjects = new SelectList(db.Subjects, "Id", "TitleSubject");
            ViewBag.GroupClasses = new SelectList(db.GroupClasses.Select(s => new
            {
                Id = s.Id,
                Class = s.YearStudy + s.Letter
            }), "Id", "Class");

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

        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var shedule = db.Shedules.Find(id);

                if (shedule != null)
                {
                    ViewBag.Teachers = new SelectList(db.Teachers, "Id", "FioTeacher", shedule.TeacherId);
                    ViewBag.Subjects = new SelectList(db.Subjects, "Id", "TitleSubject", shedule.SubjectId);
                    ViewBag.GroupClasses = new SelectList(db.GroupClasses.Select(s => new
                    {
                        Id = s.Id,
                        Class = s.YearStudy + s.Letter
                    }), "Id", "Class", shedule.GroupClassId);

                    return View(shedule);
                }
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

        public IActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var shedule = db.Shedules.Find(id);

                if (shedule != null)
                {
                    db.Shedules.Remove(shedule);
                    db.SaveChanges();
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}