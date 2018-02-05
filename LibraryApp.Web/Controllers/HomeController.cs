using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryApp.DataAccess;
using LibraryApp.DataAccess.Model;
using LibraryApp.Web.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            //var bookCategory = new BookCategory
            //{
            //    Name ="Drama"
            //};

            //_unitOfWork.BookCategories.Add(bookCategory);
            //_unitOfWork.SaveChanges();

            var bookCategories = _unitOfWork.BookCategories.GetAll();

            var bookCategoriesDto = Mapper.Map<IEnumerable<BookCategoryDto>>(bookCategories);

            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
