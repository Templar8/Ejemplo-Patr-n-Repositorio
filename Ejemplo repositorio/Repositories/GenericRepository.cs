using Ejemplo_repositorio.Data;

namespace Ejemplo_repositorio.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly LibraryContext _context;
        public GenericRepository(LibraryContext context)
        {
            this._context = context;
        }

        public virtual void Add(T entity)
        {
            this._context.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            this._context.Remove(entity);
        }

        public virtual T Get(int id)
        {
            return this._context.Find<T>(id);
        }

        public virtual void Save()
        {
            this._context.SaveChanges();
        }
    }
}
