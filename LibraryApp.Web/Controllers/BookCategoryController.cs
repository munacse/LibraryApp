using LibraryApp.Core.DataTransferObjects;
using LibraryApp.Core.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.Web.Controllers
{
    [Route("api/[controller]")]
    public class BookCategoryController : Controller
    {
        private IBookCategoryService _bookCategoryService;

        public BookCategoryController(IBookCategoryService bookCategoryService)
        {
            _bookCategoryService = bookCategoryService;
        }

        [HttpGet("[action]")]
        public IActionResult GetAllBookCategory()
        {
            var bookCategories = _bookCategoryService.GetAllBookCategory();

            return Ok(bookCategories);
        }

        [HttpPost]
        public IActionResult Post([FromBody]BookCategoryDto bookCategoryDto)
        {
            _bookCategoryService.SaveBookCategory(bookCategoryDto);

            var bookCategories = _bookCategoryService.GetAllBookCategory();

            return Ok(bookCategories);
        }
    }
}