using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp.Core.DataTransferObjects
{
    public class BookDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Page { get; set; }

        public Guid AuthorId { get; set; }

        public Guid BookCategoryId { get; set; }

        public AuthorDto AuthorDto { get; set; }

        public BookCategoryDto BookCategoryDto { get; set; }
    }
}
