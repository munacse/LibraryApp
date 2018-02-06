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
    public class AuthorController : Controller
    {
        private IUnitOfWork _unitOfWork;

        public AuthorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("[action]")]
        public IEnumerable<AuthorDto> GetAllAuthor()
        {
            var authors = _unitOfWork.Authors.GetAll();

            var authorDto = Mapper.Map<IEnumerable<AuthorDto>>(authors);

            return authorDto;
        }

        [HttpPost]
        public IEnumerable<AuthorDto> Post([FromBody]AuthorDto authorDto)
        {
            var author = Mapper.Map<AuthorDto, Author>(authorDto);
            _unitOfWork.Authors.Add(author);
            _unitOfWork.SaveChanges();

            var authors = _unitOfWork.Authors.GetAll();

            var authorDtos = Mapper.Map<IEnumerable<AuthorDto>>(authors);

            return authorDtos;
        }

    }
}