using LibraryApp.DataAccess.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.DataAccess
{
    public class LibraryAppDbContext : IdentityDbContext
    {
        public LibraryAppDbContext(DbContextOptions<LibraryAppDbContext> options)
        : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Book> Students { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<BookCategory> BookCategory { get; set; }
    }
}
