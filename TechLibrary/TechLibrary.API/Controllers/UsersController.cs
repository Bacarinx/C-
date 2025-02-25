using Microsoft.AspNetCore.Mvc;
using TechLibrary.API.UseCases.Users.Register;
using TechLibrary.Comunication;
using TechLibrary.Comunication.Requests;
using TechLibrary.Comunication.Response;
using TechLibrary.Exception;

namespace TechLibrary.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseUserRegisteredJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseRegisterValidatorJson), StatusCodes.Status400BadRequest)]
        public IActionResult Register(RequestUserJson request)
        {

            var useCase = new RegisterUserUseCases();
            var response = useCase.Execute(request);
            return Created(String.Empty, response);

        }
    }
}
