using LibraryApp.DataAccess.Model;
using System.Collections.Generic;

namespace LibraryApp.DataAccess.Repositories.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        IEnumerable<Book> GetAllBooksData();
    }
}
