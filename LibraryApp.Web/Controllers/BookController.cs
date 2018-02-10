using LibraryApp.Core.DataTransferObjects;
using LibraryApp.Core.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Web.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("[action]")]
        public IActionResult GetAllBook()
        {
            var books = _bookService.GetAllBook();

            return Ok(books);
        }

        [HttpPost]
        public IActionResult Post([FromBody]BookDto bookDto)
        {
            _bookService.SaveBook(bookDto);

            var books = _bookService.GetAllBook();

            return Ok(books);
        }
    }
}