using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebApi.API.Data;
using WebApi.API.Models.Domain;
using WebApi.API.Repositories.Interface;


namespace WebApi.API.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
            

        public async Task<Category>CreateAsync(Category category)
        {
            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

            return category;
        }
    }

}
