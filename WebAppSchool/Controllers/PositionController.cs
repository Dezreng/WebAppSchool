using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAppSchool.Data;
using WebAppSchool.Models.CodeFirst;
using X.PagedList;

namespace WebAppSchool.Controllers
{
    public class PositionController : Controller
    {
        private readonly SchoolContext db;

        public PositionController(SchoolContext context)
        {
            db = context;
        }

        public IActionResult Index(int? page, string searchPosition)
        {
            int pageSize = 30;
            int pageNumber = (page ?? 1);
            ViewData["searchPosition"] = searchPosition;

            IQueryable<Position> positions = db.Positions;

            if (!String.IsNullOrEmpty(searchPosition))
            {
                positions = positions.Where(t => t.TitlePosition.Contains(searchPosition));
            }

            return View(positions.ToPagedList(pageNumber, pageSize));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Position position)
        {
            if (ModelState.IsValid)
            {
                db.Positions.Add(position);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var position = db.Positions.Find(id);

                if (position != null)
                {
                    return View(position);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Edit(Position position)
        {
            if (ModelState.IsValid)
            {
                db.Positions.Update(position);
                db.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var position = db.Positions.Find(id);

                if (position != null)
                {
                    db.Positions.Remove(position);
                    db.SaveChanges();

                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}