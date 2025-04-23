using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderSolution.API.Context;
using OrderSolution.API.Entities;
using OrderSolution.API.Services.LoggedUser;
using OrderSolution.Comunication.Responses;
using OrderSolutions.Exception;

namespace OrderSolution.API.UseCases.Services
{
    public class UseCaseServices
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly OrderSolutionDbContext _context;
        public UseCaseServices(OrderSolutionDbContext context, IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
            _context = context;
        }

        public ResponseService StartService()
        {
            var userLogged = new LoggedUserService(_httpContext);
            var user = userLogged.getUser(_context);

            if (user == null)
                throw new ExceptionUserUnathorized();

            return new ResponseService
            {
                StartService = DateTime.UtcNow
            };
        }

        public ResponseService EndService(Service service)
        {
            var userLogged = new LoggedUserService(_httpContext);
            var user = userLogged.getUser(_context);

            if (user == null || user.Id != service.UserId)
                throw new ExceptionUserUnathorized();

            var serviceExists = _context.Services.FirstOrDefault(s => s.Id == service.Id);
            if (serviceExists == null)
                throw new ExceptionServiceNotFound();

            if (service.EndService != null)
                throw new ExceptionServiceAlreadyEnds();

            service.StartService = service.StartService;
            service.EndService = DateTime.UtcNow;

            return new ResponseService
            {
                StartService = service.StartService,
                EndService = DateTime.UtcNow
            };
        }
    }
}