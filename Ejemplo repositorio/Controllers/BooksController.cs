#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ejemplo_repositorio.Data;
using Ejemplo_repositorio.Models;
using Ejemplo_repositorio.Repositories;

namespace Ejemplo_repositorio.Controllers
{
    public class BooksController : Controller
    {
        private IBookRepository _bookRepository;
        private IShelvingRepository _shelvingRepository;
        private LibraryContext _context;

        public BooksController(LibraryContext context)
        {
            this._context = context;
        }        

        private IBookRepository BookRepository
        { 
            get
            {
                if (this._bookRepository == null)
                {
                    this._bookRepository = new BookRepository(this._context);
                }
                return this._bookRepository;
            }
        }

        // GET: Books
        public IActionResult Index()
        {
            return View(this._bookRepository.GetBooks());
        }

        // GET: Books/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = this._bookRepository.Get(id.Value);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Genre,Price")] Book book)
        {
            if (ModelState.IsValid)
            {
                this._bookRepository.Add(book);
                this._bookRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = this._bookRepository.Get(id.Value);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,Genre,Price")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this._bookRepository.UpdateBook(book);
                    this._bookRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = this._bookRepository.Get(id.Value);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Book book = this._bookRepository.Get(id);
            this._bookRepository.Delete(book);
            this._bookRepository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return this._bookRepository.Get(id) != null;
        }
    }
}
