using LibraryApp.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryApp.Core.Services.Interface
{
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorDto>> GetAllAuthor();

        Task<bool> SaveAuthor(AuthorDto authorDto);

        Task<AuthorDto> GetAuthor(Guid id);
    }
}
