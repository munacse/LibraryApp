using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Core.DataTransferObjects
{
    public class BookCategoryDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<BookDto> BookDtos { get; set; }
    }
}
