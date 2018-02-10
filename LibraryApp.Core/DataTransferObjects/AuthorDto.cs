using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Core.DataTransferObjects
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
