using LibraryApp.DataAccess.Model;
using LibraryApp.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.DataAccess.Repositories
{
    public class BookCategoryRepository : Repository<BookCategory>, IBookCategoryRepository
    {
        public BookCategoryRepository(DbContext context) : base(context)
        { }

        private LibraryAppDbContext _appContext => (LibraryAppDbContext)_context;
    }
}
