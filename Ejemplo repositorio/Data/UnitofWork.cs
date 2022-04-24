using Ejemplo_repositorio.Repositories;

namespace Ejemplo_repositorio.Data
{
    public class UnitOfWork
    {
        private ShelvingRepository _shelvingRepository;
        private BookRepository _bookRepository;
        private LibraryContext _context;

        public UnitOfWork(LibraryContext context)
        {
            this._context = context;
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

        public void Save()
        {
            this._context.SaveChanges();
        }
    }
}
