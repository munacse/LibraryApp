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
using LibraryApp.Web.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly INoteRepository _noteRepository;



        public HomeController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public IActionResult Index()
        {
            //
            //_noteRepository.AddNote(new Note()
            //{
            //    Id = "1",
            //    Body = "Test note 1",
            //    CreatedOn = DateTime.Now,
            //    UpdatedOn = DateTime.Now,
            //    UserId = 1
            //});
            //_noteRepository.AddNote(new Note()
            //{
            //    Id = "2",
            //    Body = "Test note 2",
            //    CreatedOn = DateTime.Now,
            //    UpdatedOn = DateTime.Now,
            //    UserId = 1
            //});
            //_noteRepository.AddNote(new Note()
            //{
            //    Id = "3",
            //    Body = "Test note 3",
            //    CreatedOn = DateTime.Now,
            //    UpdatedOn = DateTime.Now,
            //    UserId = 2
            //});
            //_noteRepository.AddNote(new Note()
            //{
            //    Id = "4",
            //    Body = "Test note 4",
            //    CreatedOn = DateTime.Now,
            //    UpdatedOn = DateTime.Now,
            //    UserId = 2
            //});
            //
            var result = _noteRepository.GetAllNotes();
            return View();
        }

        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
