using AutoMapper;
using LibraryApp.Core.DataTransferObjects;
using LibraryApp.Core.Services.Interface;
using LibraryApp.DataAccess;
using LibraryApp.DataAccess.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryApp.Core.Services
{
    public class BookCategoryService : IBookCategoryService
    {
        private IUnitOfWork _unitOfWork;

        public BookCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<BookCategoryDto>> GetAllBookCategory()
        {
            var bookCategories = await _unitOfWork.BookCategories.GetAll();

            var bookCategoriesDto = Mapper.Map<IEnumerable<BookCategoryDto>>(bookCategories);

            return bookCategoriesDto;
        }

        public async Task<bool> SaveBookCategory(BookCategoryDto bookCategoryDto)
        {
            var bookCategory = Mapper.Map<BookCategoryDto, BookCategory>(bookCategoryDto);

            await _unitOfWork.BookCategories.Add(bookCategory);
            await _unitOfWork.SaveChanges();

            return true;
        }
    }
}
