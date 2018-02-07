using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryApp.DataAccess;
using LibraryApp.DataAccess.Model;
using LibraryApp.Web.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Web.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public BookController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("[action]")]
        public IEnumerable<BookDto> GetAllBook()
        {
            var books = _unitOfWork.Books.GetAllBooksData();
            
            var bookDto = Mapper.Map<IEnumerable<BookDto>>(books);

            return bookDto;
        }

        [HttpPost]
        public IEnumerable<BookDto> Post([FromBody]BookDto bookDto)
        {
            var author = _unitOfWork.Authors.Get(bookDto.AuthorId);
            var bookCategory = _unitOfWork.BookCategories.Get(bookDto.BookCategoryId);
            var book = Mapper.Map<BookDto, Book>(bookDto);

            book.Author = author;
            book.BookCategory = bookCategory;

            _unitOfWork.Books.Add(book);
            _unitOfWork.SaveChanges();

            var books = _unitOfWork.Books.GetAll();
            var bookDtos = Mapper.Map<IEnumerable<BookDto>>(books);

            return bookDtos;
        }
    }
}