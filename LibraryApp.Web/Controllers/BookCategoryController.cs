using LibraryApp.Core.DataTransferObjects;
using LibraryApp.Core.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAllBookCategory()
        {
            var bookCategories = await _bookCategoryService.GetAllBookCategory();

            return Ok(bookCategories);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]BookCategoryDto bookCategoryDto)
        {
            await _bookCategoryService.SaveBookCategory(bookCategoryDto);

            var bookCategories = await _bookCategoryService.GetAllBookCategory();

            return Ok(bookCategories);
        }
    }
}