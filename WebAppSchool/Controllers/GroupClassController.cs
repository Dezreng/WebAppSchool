using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebAppSchool.Data;
using WebAppSchool.Models.CodeFirst;
using X.PagedList;

namespace WebAppSchool.Controllers
{
    public class GroupClassController : Controller
    {
        private readonly SchoolContext db;

        public GroupClassController(SchoolContext context)
        {
            db = context;
        }

        public IActionResult Index(int? page, string searchTeacher, int? searchYearCreation)
        {
            int pageSize = 30;
            int pageNumber = (page ?? 1);
            ViewData["searchTeacher"] = searchTeacher;
            ViewData["searchYearCreation"] = searchYearCreation;

            IQueryable<GroupClass> groupClasses = db.GroupClasses;

            if (!String.IsNullOrEmpty(searchTeacher))
            {
                groupClasses = groupClasses.Where(t => t.ClassRoomTeacher.Contains(searchTeacher));
            }
            if (searchYearCreation.HasValue)
            {
                groupClasses = groupClasses.Where(y => y.YearCreation == searchYearCreation);
            }

            groupClasses = groupClasses.OrderBy(i => i.Id);

            return View(groupClasses.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(GroupClass groupClass)
        {
            if (ModelState.IsValid)
            {
                db.GroupClasses.Add(groupClass);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var group = db.GroupClasses.Find(id);

                if (group != null)
                {
                    return View(group);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(GroupClass groupClass)
        {
            if (ModelState.IsValid)
            {
                db.GroupClasses.Update(groupClass);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var groupClass = db.GroupClasses.Find(id);

                if (groupClass != null)
                {
                    db.GroupClasses.Remove(groupClass);
                    db.SaveChanges();
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}