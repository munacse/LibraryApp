using LibraryApp.Core.DataTransferObjects;
using System.Collections.Generic;

namespace LibraryApp.Core.Services.Interface
{
    public interface IBookService
    {
        IEnumerable<BookDto> GetAllBook();

        bool SaveBook(BookDto bookDto);
    }
}
