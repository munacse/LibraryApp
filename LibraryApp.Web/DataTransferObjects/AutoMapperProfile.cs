using AutoMapper;
using LibraryApp.DataAccess.Model;

namespace LibraryApp.Web.DataTransferObjects
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
