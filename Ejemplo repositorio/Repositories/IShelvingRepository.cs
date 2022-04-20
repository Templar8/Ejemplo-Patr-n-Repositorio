using Ejemplo_repositorio.Models;

namespace Ejemplo_repositorio.Repositories
{
    public interface IShelvingRepository:IGenericRepository<Shelving>
    {
        IEnumerable<Shelving> GetShelvings();
        Shelving GetShelving(int shelvingId);
        void AddShelving(Shelving shelving);
        void UpdateShelving(Shelving shelving);
        void DeleteShelving(int shelvingId);
        void Save();
    }
}
