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
    public class ShelvingsController : Controller
    {
        private readonly LibraryContext _context;
        private IShelvingRepository _shelvingRepository;
        private IBookRepository _bookRepository;
        private readonly UnitOfWork _unitOfWork;

        public ShelvingsController(LibraryContext context)
        {
            this._unitOfWork = new UnitOfWork(context);
        }

        public IBookRepository BookRepository
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

        public IShelvingRepository ShelvingRepository
        {
            get
            {
                if (this._shelvingRepository == null)
                {
                    this._shelvingRepository = new ShelvingRepository(this._context);
                }
                return this._shelvingRepository;
            }
        }

        // GET: Shelvings
        public IActionResult Index()
        {
            return View(this._shelvingRepository.GetShelvings());
        }

        // GET: Shelvings/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelving = this._shelvingRepository.Get(id.Value);
            if (shelving == null)
            {
                return NotFound();
            }

            return View(shelving);
        }

        // GET: Shelvings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shelvings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id")] Shelving shelving)
        {
            if (ModelState.IsValid)
            {
                this._shelvingRepository.Add(shelving);
                this._shelvingRepository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(shelving);
        }

        // GET: Shelvings/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelving = this._shelvingRepository.Get(id.Value);
            if (shelving == null)
            {
                return NotFound();
            }
            return View(shelving);
        }

        // POST: Shelvings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id")] Shelving shelving)
        {
            if (id != shelving.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    this._shelvingRepository.UpdateShelving(shelving);
                    this._shelvingRepository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShelvingExists(shelving.Id))
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
            return View(shelving);
        }

        // GET: Shelvings/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelving = this._shelvingRepository.Get(id.Value);
            if (shelving == null)
            {
                return NotFound();
            }

            return View(shelving);
        }

        // POST: Shelvings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id, bool DeleteShelvingBooks)
        {
            Shelving shelving = this._unitOfWork.ShelvingRepository.Get(id);
            if (DeleteShelvingBooks)
            {
                Array.ForEach(shelving.Books, B => {
                    this._unitOfWork.BookRepository.Delete(B);
                });
            }
            this._unitOfWork.ShelvingRepository.Delete(shelving);
            this._unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool ShelvingExists(int id)
        {
            return this._shelvingRepository.Get(id) != null;
        }
    }
}
