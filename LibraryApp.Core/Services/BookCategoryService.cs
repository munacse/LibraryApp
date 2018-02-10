using AutoMapper;
using LibraryApp.Core.DataTransferObjects;
using LibraryApp.Core.Services.Interface;
using LibraryApp.DataAccess;
using LibraryApp.DataAccess.Model;
using System.Collections.Generic;

namespace LibraryApp.Core.Services
{
    public class BookCategoryService : IBookCategoryService
    {
        private IUnitOfWork _unitOfWork;

        public BookCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<BookCategoryDto> GetAllBookCategory()
        {
            var bookCategories = _unitOfWork.BookCategories.GetAll();

            var bookCategoriesDto = Mapper.Map<IEnumerable<BookCategoryDto>>(bookCategories);

            return bookCategoriesDto;
        }

        public bool SaveBookCategory(BookCategoryDto bookCategoryDto)
        {
            var bookCategory = Mapper.Map<BookCategoryDto, BookCategory>(bookCategoryDto);

            _unitOfWork.BookCategories.Add(bookCategory);
            _unitOfWork.SaveChanges();

            return true;
        }
    }
}
