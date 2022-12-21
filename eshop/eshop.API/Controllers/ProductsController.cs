using eshop.Application;
using Microsoft.AspNetCore.Mvc;
using shop.Entities;

namespace eshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        [HttpGet]
        public IActionResult Get()
        {
            var products = _productService.GetProducts();
            return Ok(products);
        }


        [HttpGet("[action]/{name}")]
        //[Route("[action]")]
        public IActionResult SearchByName(string name)
        {
            var products = _productService.GetProducts(name);
            return Ok(products);
        }

        [HttpGet("[action]/{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetProduct(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddAsync(product);
                return CreatedAtAction(nameof(GetById), new { id = product.Id }, null);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id,
                                                [FromBody] Product product)
        {
            bool isExist = await _productService.ProductIsExistAsync(id);
            if (isExist)
            {
                if (ModelState.IsValid)
                {
                    await _productService.UpdateProductAsync(product);
                    return Ok(new { message = $"İşlem başarıyla tamamlandı. {id} id'li ürün güncellendi" });
                }
                return BadRequest(ModelState);
            }
            return BadRequest(new { message = $"{id} id'li ürün veritabanında bulunamadı" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool isExist = await _productService.ProductIsExistAsync(id);
            if (isExist)
            {
                await _productService.DeleteProductAsync(id);
                return Ok();
            }
            return BadRequest(new { message = $"{id} id'li ürün veritabanında bulunamadı" });
        }


    }
}
