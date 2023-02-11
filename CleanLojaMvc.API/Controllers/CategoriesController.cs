using CleanLojaMvc.Application.DTOs;
using CleanLojaMvc.Application.Insterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanLojaMvc.API.Controllers
{
    [Route("api/controller")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetCategories();
            if(categories == null)
            {
                 return NotFound("Categories not found");
            }

            return Ok(categories);
        }

        [Route("{id:int}", Name = "GetCategory")]
        [HttpGet]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var categorie = await _categoryService.GetById(id);
            if (categorie == null)
            {
                return NotFound("Category not found");
            }

            return Ok(categorie);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> Post([FromBody] CategoryDTO categorieDto)
        {           
            if (categorieDto == null)
            {
                return BadRequest("Invalid Data");
            }

            await _categoryService.Add(categorieDto);

            return new CreatedAtRouteResult("GetCategory", new { id = categorieDto.Id });
        }

        [HttpPut]
        public async Task<ActionResult<CategoryDTO>> Post(int id, [FromBody] CategoryDTO categorieDto)
        {
            if (id != categorieDto.Id) return BadRequest();

            if (categorieDto == null) return BadRequest("Invalid Data");

            await _categoryService.Update(categorieDto);

            return Ok(categorieDto);
        }

        [HttpDelete]
        public async Task<ActionResult<CategoryDTO>> Delete(int id)
        {
            var categorie = await _categoryService.GetById(id);
            if (categorie == null)
            {
                return NotFound("Category not found");
            }

            await _categoryService.Remove(id);

            return Ok(categorie);
        }
    }
}
