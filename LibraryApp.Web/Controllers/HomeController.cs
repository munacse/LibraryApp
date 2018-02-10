using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryApp.DataAccess;
using LibraryApp.DataAccess.Model;
using LibraryApp.Mongo.Interfaces;
using LibraryApp.Mongo.Model;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWorkMongo _unitOfWorkMongo;

        public HomeController(
            //IUnitOfWorkMongo unitOfWorkMongo
            )
        {
            //_unitOfWorkMongo = unitOfWorkMongo;
        }

        public IActionResult Index()
        {
            //var emmp = _unitOfWorkMongo.EmployeeRepository.GetAllEmployees();
            //
            //_noteRepository.AddNote(new Note()
            //{
            //    Id = "1",
            //    Body = "Test note 1",
            //    CreatedOn = DateTime.Now,
            //    UpdatedOn = DateTime.Now,
            //    UserId = 1
            //});
            //var product = new Product
            //{
            //    Id = "2",
            //    Name = "Colgate",
            //    CompanyName = "Uniliver",
            //    Price = 60,
            //    EntryDate = DateTime.Now
            //};
            //_unitOfWorkMongo.ProductRepository.AddProduct(product);
            //
            //var result = _unitOfWorkMongo.NoteRepository.GetAllNotes();
            //var productResult = _unitOfWorkMongo.ProductRepository.GetAllProducts();
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
