using System;
using AutoMapper;
using LibraryApp.Core.DataTransferObjects;
using LibraryApp.Core.Services.Interface;
using LibraryApp.DataAccess;
using LibraryApp.DataAccess.Model;
using System.Collections.Generic;

namespace LibraryApp.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<AuthorDto> GetAllAuthor()
        {
            var authors = _unitOfWork.Authors.GetAll();

            var authorDtos = Mapper.Map<IEnumerable<AuthorDto>>(authors);

            return authorDtos;
        }

        public AuthorDto GetAuthor(Guid id)
        {
            var author = _unitOfWork.Authors.Get(id);

            var authorDto = Mapper.Map<AuthorDto>(author);

            return authorDto;
        }

        public bool SaveAuthor(AuthorDto authorDto)
        {
            var author = Mapper.Map<AuthorDto, Author>(authorDto);

            _unitOfWork.Authors.Add(author);
            _unitOfWork.SaveChanges();

            return true;
        }
    }
}
