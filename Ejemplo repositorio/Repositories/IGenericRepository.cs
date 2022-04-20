namespace Ejemplo_repositorio.Repositories
{
    public interface IGenericRepository<T>
        where T : class
    {
        void Add(T entity);
        void Delete(T Entity);
        T Get(int id);
    }
}
