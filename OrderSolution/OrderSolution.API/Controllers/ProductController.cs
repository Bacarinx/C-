using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderSolution.API.Context;
using OrderSolution.API.Entities;
using OrderSolution.API.UseCases.Product;
using OrderSolution.Comunication.Responses;

namespace OrderSolution.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly OrderSolutionDbContext _context;
        private readonly HttpContext _httpContext;

        public ProductController(OrderSolutionDbContext context, HttpContext httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ResponseProduct>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ExceptionRegisterUserResponse), StatusCodes.Status400BadRequest)]
        public IActionResult ListProducts()
        {
            var useCase = new UseCaseProduct(_context, _httpContext);
            var produtos = useCase.ListarProdutosPorCategoria();
            return Ok(produtos);
        }
    }
}