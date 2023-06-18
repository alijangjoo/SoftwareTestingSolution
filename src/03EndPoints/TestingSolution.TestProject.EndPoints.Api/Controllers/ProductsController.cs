using Microsoft.AspNetCore.Mvc;
using TestingSolution.TestProject.Core.Contracts.Common.Exceptions;
using TestingSolution.TestProject.Core.Contracts.Products.Commands.CreateProduct;
using TestingSolution.TestProject.Core.Contracts.Products.Commands.DeleteProduct;
using TestingSolution.TestProject.Core.Contracts.Products.Commands.UpdateProduct;
using TestingSolution.TestProject.Core.Contracts.Products.Constants.Dtos;
using TestingSolution.TestProject.Core.Contracts.Products.Queries;

namespace TestingSolution.TestProject.EndPoints.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductQueryRepository _productQueryRepository;

        public ProductsController(IProductQueryRepository productQueryRepository)
        {
            _productQueryRepository = productQueryRepository;
        }

        [HttpGet]
        public ActionResult<List<ProductResponseDto>> GetProducts()
        {
            return Ok(_productQueryRepository.GetProducts());
        }

        [HttpGet("{id}")]
        public ActionResult GetProductById(int id)
        {
            try
            {
                var product = _productQueryRepository.GetProductById(id);
                return Ok(product);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Create([FromServices] ICreateProductCommandHandler createProductCommandHandler, CreateProductCommand request)
        {
            var product = createProductCommandHandler.Execute(request);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromServices] IUpdateProductCommandHandler updateProductCommandHandler, int id, UpdateProductCommand request)
        {
            try
            {
                var product = updateProductCommandHandler.Execute(request, id);
                return Ok(product);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromServices] IDeleteProductCommandHandler deleteProductCommandHandler, int id)
        {
            try
            {
                deleteProductCommandHandler.Execute(new DeleteProductCommand()
                {
                    ProductId = id
                });

                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
    }
}