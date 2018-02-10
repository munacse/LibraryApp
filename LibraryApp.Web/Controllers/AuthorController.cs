using LibraryApp.Core.DataTransferObjects;
using LibraryApp.Core.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Web.Controllers
{
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("[action]")]
        public IActionResult GetAllAuthor()
        {
            var authors = _authorService.GetAllAuthor();

            return Ok(authors);
        }

        [HttpPost]
        public IActionResult Post([FromBody]AuthorDto authorDto)
        {
            _authorService.SaveAuthor(authorDto);

            var authors = _authorService.GetAllAuthor();

            return Ok(authors);
        }

    }
}