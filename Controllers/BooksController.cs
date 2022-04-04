using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// HttpGet Index
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            IEnumerable<Book> listBooks = _context.Book;
            return View(listBooks);
        }

        /// <summary>
        /// HttpGet Create
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Create a new book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Book.Add(book);
                _context.SaveChanges();

                TempData["message"] = "The book has beed created succesfuly";
                return RedirectToAction("Index");
            }

            return View();
        }

        /// <summary>
        /// HttpGet Edit
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            //Obtains id
            var book = _context.Book.Find(id);

            if (book == null)
                return NotFound();

            return View(book);
        }

        /// <summary>
        /// Edit a specific book
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Book.Update(book);
                _context.SaveChanges();

                TempData["message"] = "The book has beed updated succesfuly";
                return RedirectToAction("Index");
            }

            return View();
        }

        /// <summary>
        /// HttpGet Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            //Obtains id
            var book = _context.Book.Find(id);

            if (book == null)
                return NotFound();

            return View(book);
        }

        /// <summary>
        /// Delete a specific book
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteBook(int? id)
        {
            //Obtains book id
            var book = _context.Book.Find(id);

            if (book == null)
                return NotFound();

            _context.Book.Remove(book);
            _context.SaveChanges();

            TempData["message"] = "The book has beed deleted";
            return RedirectToAction("Index");
        }
    }
}
