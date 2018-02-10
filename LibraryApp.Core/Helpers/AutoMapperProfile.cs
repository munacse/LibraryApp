using AutoMapper;
using LibraryApp.Core.DataTransferObjects;
using LibraryApp.DataAccess.Model;

namespace LibraryApp.Core.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();

            CreateMap<BookCategory, BookCategoryDto>().ReverseMap();

            CreateMap<Author, AuthorDto>().ReverseMap();
        }
    }
}
