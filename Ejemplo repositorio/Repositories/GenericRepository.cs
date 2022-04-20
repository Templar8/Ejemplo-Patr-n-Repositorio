using Ejemplo_repositorio.Data;

namespace Ejemplo_repositorio.Repositories
{
    public class GenericRepository<T> 
        where T : class, IGenericRepository<T>
    {
        private readonly LibraryContext _context;
        public GenericRepository(LibraryContext context)
        {
            this._context = context;
        }

        public void Add(T entity)
        {
            this._context.Add(entity);
        }

        public void Delete(T entity)
        {
            this._context.Remove(entity);
        }

        public T Get(int id)
        {
            return this._context.Find<T>(id);
        }
    }
}
