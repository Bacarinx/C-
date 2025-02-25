using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechLibrary.API.Infrastructure.Context;
using TechLibrary.API.UseCases.Books;
using TechLibrary.Comunication.Requests;
using TechLibrary.Comunication.Response;

namespace TechLibrary.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(ResponseBooks), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Filter(int pageNumber, string? title)
        {
            var useCase = new FilterBookUseCase();
            var result = useCase.Execute(new RequestBookFilter
            {
                BookName = title,
                PageNumber = pageNumber
            });

            if(result.Books.Count > 0)
            {
                return Ok(result);
            }

            return NoContent();
        }
    }
}
