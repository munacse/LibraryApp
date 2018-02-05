using System;
using System.Collections.Generic;

namespace LibraryApp.Web.DataTransferObjects
{
    public class BookCategoryDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<BookDto> BookDtos { get; set; }
    }
}
