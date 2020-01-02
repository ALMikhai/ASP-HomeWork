using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_4.Models;
using task_4.Models.Entities;

namespace task_4.Controllers
{
    public class AuthorController : Controller
    {
        private ShopContext _context;

        public AuthorController(ShopContext context)
        {
            _context = context;
        }

        // GET: Author
        public ActionResult Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.SecondNameSortParm = sortOrder == "SecondName" ? "SecondName_desc" : "SecondName";
            var authors = from a in _context.Authors
                select a;
            if (!String.IsNullOrEmpty(searchString))
            {
                authors = authors.Where(s => s.FirstName.Contains(searchString)
                                               || s.SecondName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Name_desc":
                    authors = authors.OrderByDescending(s => s.FirstName);
                    break;
                case "SecondName":
                    authors = authors.OrderBy(s => s.SecondName);
                    break;
                case "SecondName_desc":
                    authors = authors.OrderByDescending(s => s.SecondName);
                    break;
                default:
                    authors = authors.OrderBy(s => s.FirstName);
                    break;
            }
            return View(authors.ToList());
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            Author author = _context.Authors.Find(id);
            if (author == null)
                return NotFound();
            return View(author);
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Author/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author author)
        {
            try
            {
                author.CreationDateTime = DateTime.Now;
                _context.Authors.Add(author);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Author/Edit/5
        public ActionResult Edit(int id)
        {
            Author author = _context.Authors.Find(id);
            if (author == null)
                return NotFound();
            return View(author);
        }

        // POST: Author/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Author author)
        {
            try
            {
                _context.Authors.Update(author);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Author/Delete/5
        public ActionResult Delete(int id)
        {
            Author author = _context.Authors.Find(id);
            if (author == null)
                return NotFound();
            return View(author);
        }

        // POST: Author/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Author author)
        {
            try
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}