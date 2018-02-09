using LibraryApp.DataAccess.Repositories.Interfaces;

namespace LibraryApp.DataAccess
{
    public interface IUnitOfWork
    {
        IBookCategoryRepository BookCategories { get; }

        IBookRepository Books { get; }

        IAuthorRepository Authors { get; }

        int SaveChanges();
    }
}
