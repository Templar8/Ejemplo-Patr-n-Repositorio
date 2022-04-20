using Ejemplo_repositorio.Data;
using Ejemplo_repositorio.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejemplo_repositorio.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository, IDisposable
    {
        private readonly LibraryContext _bookContext;
        public BookRepository(LibraryContext context)
            :base(context)
        {
            this._bookContext = context;
        }        

        public IEnumerable<Book> GetBooks()
        {
            return this._bookContext.Books.ToList();
        }

        public void Save()
        {
            this._bookContext.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            this._bookContext.Books.Update(book);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                this._bookContext.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
