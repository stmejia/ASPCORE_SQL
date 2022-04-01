﻿using BookStore.Data;
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
    }
}
