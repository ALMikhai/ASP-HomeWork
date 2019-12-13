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
        public ActionResult Index()
        {
            return View(_context.Authors.ToList());
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