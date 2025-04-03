using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderSolution.API.Context;
using OrderSolution.API.Entities;
using OrderSolution.API.UseCases.ServiceClient;

namespace OrderSolution.API.Controllers
{
    [ApiController]
    public class ServiceClientsController : ControllerBase
    {
        private readonly OrderSolutionDbContext _context;
        private readonly IHttpContextAccessor _httpcontext;
        public ServiceClientsController(OrderSolutionDbContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpcontext = httpContext;
        }


        [Route("[controller]")]
        public IActionResult Create(Service service, Client client)
        {
            var useCase = new UseCaseServiceClient(_context, _httpcontext);
            useCase.AddClientInService(service, client);
            return Created(String.Empty, new
            {
                service,
                client
            });
        }
    }
}