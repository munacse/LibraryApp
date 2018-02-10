using LibraryApp.Core.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryApp.Core.Services.Interface
{
    public interface IBookCategoryService
    {
        Task<IEnumerable<BookCategoryDto>> GetAllBookCategory();

        Task<bool> SaveBookCategory(BookCategoryDto bookCategoryDto);
    }
}
