using System;
using AutoMapper;
using LibraryApp.Core.DataTransferObjects;
using LibraryApp.Core.Services.Interface;
using LibraryApp.DataAccess;
using LibraryApp.DataAccess.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryApp.Core.Services
{
    public class AuthorService : IAuthorService
    {
        private IUnitOfWork _unitOfWork;

        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAuthor()
        {
            var authors = await _unitOfWork.Authors.GetAll();

            var authorDtos = Mapper.Map<IEnumerable<AuthorDto>>(authors);

            return authorDtos;
        }

        public async Task<AuthorDto> GetAuthor(Guid id)
        {
            var author = await _unitOfWork.Authors.Get(id);

            var authorDto = Mapper.Map<AuthorDto>(author);

            return authorDto;
        }

        public async Task<bool> SaveAuthor(AuthorDto authorDto)
        {
            var author = Mapper.Map<AuthorDto, Author>(authorDto);

            await _unitOfWork.Authors.Add(author);
            await _unitOfWork.SaveChanges();

            return true;
        }
    }
}
