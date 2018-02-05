using LibraryApp.DataAccess.Model;
using LibraryApp.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.DataAccess.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(DbContext context) : base(context)
        { }

        private LibraryAppDbContext _appContext => (LibraryAppDbContext)_context;
    }
}
