using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderSolution.API.Context;
using OrderSolution.API.Entities;
using OrderSolution.API.Services.LoggedUser;
using OrderSolution.API.Validations;
using OrderSolution.Comunication.Requests;
using OrderSolution.Comunication.Responses;
using OrderSolutions.Exception;

namespace OrderSolution.API.UseCases.Product
{
    public class UseCaseProduct
    {
        private readonly OrderSolutionDbContext _context;
        private readonly HttpContext _httpContext;

        public UseCaseProduct(OrderSolutionDbContext context, HttpContext httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        public ResponseProduct CriarProduto(RequestNewProduct request) 
        {
            var validator = new ValidationProductRegister();
            var responseValidation = validator.Validate(request);

            if(!responseValidation.IsValid)
            {
                var errors = responseValidation.Errors.Select(error => error.ErrorMessage).ToList();
                var errormensages = new ExceptionRegisterUserResponse();
                var errorList = errormensages.Errors = errors;
                throw new ExceptionUserRegister(errorList);
            }

            var loggedUser = new LoggedUserService(_httpContext);
            var ActualLoggedUser = loggedUser.getUser(_context);

            _context.Products.Add(new Entities.Product
            {
                Name = request.Name,
                CategoryId = request.CategoryId,
                UserId = ActualLoggedUser.Id
            });

            return new ResponseProduct{
                Name = request.Name,
                CategoryId = request.CategoryId
            };
        }

        public List<ResponseProduct> ListarProdutosPorCategoria()
        {
            var query = _context.Products.AsQueryable();
            var result = query.OrderBy(product => product.Name);

            List<ResponseProduct> produtos = result.Select(produto => new ResponseProduct
            {
                Name = produto.Name,
                CategoryId = produto.CategoryId
            }).ToList();

            if(produtos.Count == 0)
              throw new ExceptionProductsNotFound();

            return produtos;
        }


    }
}