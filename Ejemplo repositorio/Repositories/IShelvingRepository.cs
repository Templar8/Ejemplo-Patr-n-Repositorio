using Ejemplo_repositorio.Models;

namespace Ejemplo_repositorio.Repositories
{
    public interface IShelvingRepository : IGenericRepository<Shelving>
    {
        void UpdateShelving(Shelving shelving);
        IEnumerable<Shelving> GetShelvings();
    }
}
