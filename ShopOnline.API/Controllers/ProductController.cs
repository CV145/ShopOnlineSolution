using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.API.ExtensionMethods;
using ShopOnline.API.Repositories.Contracts;
using ShopOnline.Models.DTOs;

namespace ShopOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //Dependency injection
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        //Action method for GET running asynchronously
        //ActionResult = response
        //Use project references to reference other projects (within Dependencies)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
        {
            try
            {
                //2 separate queries to the database
                var products = await this.productRepository.GetItems();
                var productCategories = await this.productRepository.GetCategories();

                //1 query to get both products and productCategories
                /*
                 * var products = await shopOnlineDbContext.Products.Include(p => p.ProductCategory).ToListAsync();
                 */

                if (products == null || productCategories == null)
                {
                    return NotFound();
                }
                else
                {
                    var productDtos = products.ConvertToDto(productCategories);
                    return Ok(productDtos);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database");
            }
        }
    }
}
