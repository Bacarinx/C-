using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechLibrary.API.UseCases.Users.Login;
using TechLibrary.Comunication.Requests;
using TechLibrary.Comunication.Response;

namespace TechLibrary.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseUserRegisteredJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseRegisterValidatorJson), StatusCodes.Status401Unauthorized)]
        public IActionResult Login(RequestLoginJson request)
        {
            var UseCase = new LoginUseCase();
            var response = UseCase.Execute(request);
            return Ok(response);
        }
    }
}
