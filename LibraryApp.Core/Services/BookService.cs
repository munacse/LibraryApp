using AutoMapper;
using LibraryApp.Core.DataTransferObjects;
using LibraryApp.Core.Services.Interface;
using LibraryApp.DataAccess;
using LibraryApp.DataAccess.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryApp.Core.Services
{
    public class BookService : IBookService
    {
        private IUnitOfWork _unitOfWork;

        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<BookDto> GetAllBook()
        {
            var books = _unitOfWork.Books.GetAllBooksData();

            var bookDto = Mapper.Map<IEnumerable<BookDto>>(books);

            return bookDto;
        }

        public async Task<bool> SaveBook(BookDto bookDto)
        {
            var author = await _unitOfWork.Authors.Get(bookDto.AuthorId);
            var bookCategory = await _unitOfWork.BookCategories.Get(bookDto.BookCategoryId);
            var book = Mapper.Map<BookDto, Book>(bookDto);

            book.Author = author;
            book.BookCategory = bookCategory;

            await _unitOfWork.Books.Add(book);
            await _unitOfWork.SaveChanges();

            return true;
        }
    }
}
