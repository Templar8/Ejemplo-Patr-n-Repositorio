using Ejemplo_repositorio.Models;

namespace Ejemplo_repositorio.Repositories
{
    public interface IShelvingRepository:IGenericRepository<Shelving>
    {
        IEnumerable<Shelving> GetShelvings();
        void Save();
    }
}
