using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.API.Data;
using WebApi.API.Models.Domain;
using WebApi.API.Models.DTO;
using WebApi.API.Repositories.Interface;

namespace WebApi.API.Controllers


//add path https:localhost/xxxx/api/categories
{
    [Route("api/[controller]")]
    [ApiController]


    public class CategoriesController : ControllerBase
    {
   
        private readonly ICategoryRepository categoryRepository;

        // make the constructor

        public CategoriesController(ICategoryRepository categoryRepository){

            this.categoryRepository = categoryRepository;
        }

        [HttpPost]

        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        {

            // DTO Map to Domain Models

            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle,
            };


             await categoryRepository.CreateAsync(category);

            //Domain model to DTO response

            var response = new CategoryDto
            {
                Id = category.Id,

                Name = category.Name,

                UrlHandle = category.UrlHandle,

            };

            return Ok(response);
        }
    }
}
