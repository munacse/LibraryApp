using System;

namespace LibraryApp.Web.DataTransferObjects
{
    public class BookDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Page { get; set; }

        public AuthorDto AuthorDto { get; set; }

        public BookCategoryDto BookCategoryDto { get; set; }
    }
}
