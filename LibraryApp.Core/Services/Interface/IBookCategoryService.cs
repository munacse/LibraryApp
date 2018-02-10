using LibraryApp.Core.DataTransferObjects;
using System.Collections.Generic;

namespace LibraryApp.Core.Services.Interface
{
    public interface IBookCategoryService
    {
        IEnumerable<BookCategoryDto> GetAllBookCategory();

        bool SaveBookCategory(BookCategoryDto bookCategoryDto);
    }
}
