using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryApp.DataAccess;
using LibraryApp.Web.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Web.Controllers
{
    [Route("api/[controller]")]
    public class BookCategoryController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public BookCategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("[action]")]
        public IEnumerable<BookCategoryDto> GetAllBookCategory()
        {
            var bookCategories = _unitOfWork.BookCategories.GetAll();

            var bookCategoriesDto = Mapper.Map<IEnumerable<BookCategoryDto>>(bookCategories);

            return bookCategoriesDto;
        }
    }
}