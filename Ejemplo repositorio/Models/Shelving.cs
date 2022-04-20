namespace Ejemplo_repositorio.Models
{
    public class Shelving
    {
        public int Id { get; set; }
        string Location { get; set; }
        int NumberOfBooks { get; set; }
        int Number { get; set; }
        string Letter { get; set; }
        public Book[] Books { get; set; }
    }
}
