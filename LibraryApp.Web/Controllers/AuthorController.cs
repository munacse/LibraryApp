using LibraryApp.Core.DataTransferObjects;
using LibraryApp.Core.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAllAuthor()
        {
            var authors = await _authorService.GetAllAuthor();

            return Ok(authors);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AuthorDto authorDto)
        {
            await _authorService.SaveAuthor(authorDto);

            var authors = await _authorService.GetAllAuthor();

            return Ok(authors);
        }

    }
}