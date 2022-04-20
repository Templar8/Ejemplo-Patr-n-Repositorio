using Ejemplo_repositorio.Data;
using Microsoft.EntityFrameworkCore;

namespace Ejemplo_repositorio.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<LibraryContext>>()))
            {
                if (context == null || context.Books == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies.
                if (context.Books.Any())
                {
                    return;   // DB has been seeded
                }

                context.Books.AddRange(
                    new Book
                    {
                        Title = "When Harry Met Sally",
                        Genre = "Romantic Comedy",
                        Price = 7.99M
                    },

                    new Book
                    {
                        Title = "Ghostbusters ",
                        Genre = "Comedy",
                        Price = 8.99M
                    },

                    new Book
                    {
                        Title = "Ghostbusters 2",
                        Genre = "Comedy",
                        Price = 9.99M
                    },

                    new Book
                    {
                        Title = "Rio Bravo",
                        Genre = "Western",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
