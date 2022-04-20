using Ejemplo_repositorio.Models;

namespace Ejemplo_repositorio.Repositories
{
    public interface IBookRepository:IGenericRepository<Book>
    {
        IEnumerable<Book> GetBooks();
        Book GetBook(int bookId);
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(int bookId);
        void Save();
    }
}
