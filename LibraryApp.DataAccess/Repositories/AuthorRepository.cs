using LibraryApp.DataAccess.Model;
using LibraryApp.DataAccess.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.DataAccess.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(DbContext context) : base(context)
        { }

        private LibraryAppDbContext _appContext => (LibraryAppDbContext)_context;
    }
}
