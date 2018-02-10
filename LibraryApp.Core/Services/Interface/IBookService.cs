using LibraryApp.Core.DataTransferObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryApp.Core.Services.Interface
{
    public interface IBookService
    {
        IEnumerable<BookDto> GetAllBook();

        Task<bool> SaveBook(BookDto bookDto);
    }
}
