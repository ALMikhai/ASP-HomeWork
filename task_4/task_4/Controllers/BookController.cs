using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using task_4.Models;
using task_4.Models.Entities;

namespace task_4.Controllers
{
    public class BookController : Controller
    {
        private ShopContext _context;

        public BookController(ShopContext context)
        {
            _context = context;
        }

        // GET: Book +
        public ActionResult Index()
        {
            return View(_context.Books.ToList());
        }

        // GET: Book/Details/5 +
        public ActionResult Details(int id)
        {
            Book book = _context.Books.Find(id);
            if (book == null)
                return NotFound();
            return View(book);
        }

        // GET: Book/Create +
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create +
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5 
        public ActionResult Edit(int id)
        {
            Book book = _context.Books.Find(id);
            if (book == null)
                return NotFound();
            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            try
            {
                _context.Books.Update(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            Book book = _context.Books.Find(id);
            if (book == null)
                return NotFound();
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Book book)
        {
            try
            {
                _context.Books.Remove(book);
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