using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using TechLibrary.API.Services.LoggedUser;
using TechLibrary.API.UseCases.Checkout;

namespace TechLibrary.API.Controllers
{
    [Route("[controller]")]
    [ApiController]

    public class BookCheckoutController : ControllerBase
    {
        [HttpPost]
        [Route("{bookId}")]
        [Authorize]
        public IActionResult BookCheckout(Guid bookId)
        {
            var useCase = new CheckoutBookUseCase(HttpContext);
            useCase.Execute(bookId);
            return Ok();
        }
    }
}
