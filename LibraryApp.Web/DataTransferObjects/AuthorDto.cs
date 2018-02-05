using System;
using System.Collections.Generic;

namespace LibraryApp.Web.DataTransferObjects
{
    public class AuthorDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public ICollection<BookDto> BookDto { get; set; }
    }
}
