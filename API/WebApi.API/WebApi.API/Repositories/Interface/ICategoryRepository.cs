using WebApi.API.Models.Domain;

namespace WebApi.API.Repositories.Interface
{
    public interface ICategoryRepository
    {

        Task<Category> CreateAsync(Category category);

    }
}