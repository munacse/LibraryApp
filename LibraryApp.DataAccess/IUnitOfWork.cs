using LibraryApp.DataAccess.Repositories.Interfaces;
using System.Threading.Tasks;

namespace LibraryApp.DataAccess
{
    public interface IUnitOfWork
    {
        IBookCategoryRepository BookCategories { get; }

        IBookRepository Books { get; }

        IAuthorRepository Authors { get; }

        Task<int> SaveChanges();
    }
}