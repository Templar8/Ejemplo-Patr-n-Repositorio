using Ejemplo_repositorio.Models;

namespace Ejemplo_repositorio.Repositories
{
    public interface IBookRepository:IGenericRepository<Book>
    {
        IEnumerable<Book> GetBooks();
        void UpdateBook(Book book);
        void Save();
    }
}
