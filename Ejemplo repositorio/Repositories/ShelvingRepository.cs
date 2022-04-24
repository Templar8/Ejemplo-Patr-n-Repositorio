using Ejemplo_repositorio.Data;
using Ejemplo_repositorio.Models;

namespace Ejemplo_repositorio.Repositories
{
    public class ShelvingRepository :  GenericRepository<Shelving>, IShelvingRepository
    {
        private readonly LibraryContext _libraryContext;
        public ShelvingRepository(LibraryContext context)
            :base(context)
        {
            this._libraryContext = context;
        }        

        public IEnumerable<Shelving> GetShelvings()
        {
            return this._libraryContext.Shelvings.ToList();
        }

        public void Save()
        {
            this._libraryContext.SaveChanges();
        }

        public void UpdateShelving(Shelving shelving)
        {
            this._libraryContext.Shelvings.Update(shelving);
        }
    }
}
