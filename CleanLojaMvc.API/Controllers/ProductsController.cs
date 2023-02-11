using CleanLojaMvc.Application.DTOs;
using CleanLojaMvc.Application.Insterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanLojaMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _environment;

        public ProductsController(IProductService productAppService,
            ICategoryService categoryService, IWebHostEnvironment environment)
        {
            _productService = productAppService;
            _categoryService = categoryService;
            _environment = environment;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            var products = await _productService.GetProducts();
            if (products == null)
            {
                return NotFound("Products not found");
            }

            return Ok(products);
        }

        [Route("{id:int}", Name = "GetProduct")]
        [HttpGet]
        public async Task<ActionResult<ProductDTO>> Get(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }

            return Ok(product);
        }


        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Post([FromBody(EmptyBodyBehavior = Microsoft.AspNetCore.Mvc.ModelBinding.EmptyBodyBehavior.Allow)] ProductDTO productDto)
        {
            if (productDto == null) return BadRequest("Invalid Data");

            await _productService.Add(productDto);

            return new CreatedAtRouteResult("GetProduct", new { id = productDto.Id });
        }

        [HttpPut]
        public async Task<ActionResult<ProductDTO>> Put(int id, [FromBody(EmptyBodyBehavior = Microsoft.AspNetCore.Mvc.ModelBinding.EmptyBodyBehavior.Allow)] ProductDTO productDto)
        {
            ModelState.Remove("Category");
            if (id != productDto.Id) return BadRequest("Data invalid");
            if (productDto == null) return BadRequest("Data invalid");

            await _productService.Update(productDto);

            return Ok(productDto);
        }

        [HttpDelete]
        public async Task<ActionResult<ProductDTO>> Delete(int id)
        {
            var producDto = await _productService.GetById(id);

            if (producDto == null)
            {
                return NotFound("Product not found");
            }

            await _productService.Remove(id);

            return Ok(producDto);
        }
    }
}
