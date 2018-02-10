using LibraryApp.DataAccess.Model;
using LibraryApp.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryApp.DataAccess.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(DbContext context) : base(context)
        { }

        public IEnumerable<Book> GetAllBooksData()
        {
            return _appContext.Students
                .Include(c => c.BookCategory).ThenInclude(o => o.Books)
                .Include(c => c.Author).ThenInclude(o => o.Books)
                ;
        }

        private LibraryAppDbContext _appContext => (LibraryAppDbContext)_context;
    }
}
