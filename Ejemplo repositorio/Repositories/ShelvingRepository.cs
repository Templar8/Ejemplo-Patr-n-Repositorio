using Ejemplo_repositorio.Data;
using Ejemplo_repositorio.Models;

namespace Ejemplo_repositorio.Repositories
{
    public class ShelvingRepository : IShelvingRepository
    {

        private readonly LibraryContext _libraryContext;
        public ShelvingRepository(LibraryContext context)
        {
            this._libraryContext = context;
        }
        public void AddShelving(Shelving shelving)
        {
            this._libraryContext.Shelvings.Add(shelving);
        }

        public void DeleteShelving(int shelvingId)
        {
            this._libraryContext.Shelvings.Remove(this.GetShelving(shelvingId));
        }

        public Shelving GetShelving(int shelvingId)
        {
            return this._libraryContext.Shelvings.Find(shelvingId);
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
