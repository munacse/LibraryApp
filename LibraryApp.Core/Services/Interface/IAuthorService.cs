using LibraryApp.Core.DataTransferObjects;
using System;
using System.Collections.Generic;

namespace LibraryApp.Core.Services.Interface
{
    public interface IAuthorService
    {
        IEnumerable<AuthorDto> GetAllAuthor();

        bool SaveAuthor(AuthorDto authorDto);

        AuthorDto GetAuthor(Guid id);
    }
}
