using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebAppSchool.Data;
using WebAppSchool.Models.CodeFirst;

namespace WebAppSchool.Controllers
{
    public class GroupClassController : Controller
    {
        private readonly SchoolContext db;

        public GroupClassController(SchoolContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var group = db.GroupClasses.ToList();
            return View(group);
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

        public IActionResult Edit(int id)
        {
            var group = db.GroupClasses.Find(id);

            if (group != null)
            {
                return View(group);
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
    }
}