using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using WebAppSchool.Data;
using WebAppSchool.Models.CodeFirst;

namespace WebAppSchool.Controllers
{
    public class PositionController : Controller
    {
        private readonly SchoolContext db;

        public PositionController(SchoolContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var positionList = db.Positions.ToList();
            return View(positionList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Position position)
        {
            if (position != null)
            {
                db.Positions.Add(position);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var position = db.Positions.FirstOrDefault(i => i.Id == id);

            if (position != null)
            {
                return View(position);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Position position)
        {
            if (position != null)
            {
                db.Positions.Update(position);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}