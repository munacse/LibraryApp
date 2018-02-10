using FluentAssertions;
using LibraryApp.DataAccess;
using LibraryApp.DataAccess.Repositories;
using LibraryApp.DataAccess.Repositories.Interfaces;
using LibraryApp.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.Core.Services.Interface;
using Xunit;
using LibraryApp.Core.DataTransferObjects;

namespace LibraryApp.Tests
{
    public class AuthorControllerUnitTests
    {
        [Fact]
        public void Values_Get_All()
        {
            var authorService = new Mock<IAuthorService>();


            // Arrange
            var controller = new AuthorController(authorService.Object);

            // Act
            var result = controller.GetAllAuthor();

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var authorDtos = okResult.Value.Should().BeAssignableTo<IEnumerable<AuthorDto>>().Subject;

            authorDtos.Count().Should().BeGreaterThan(0);

        }
    }
}
