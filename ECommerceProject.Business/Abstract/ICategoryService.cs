using ECommerceProject.Entities.Models;
namespace ECommerceProject.Business.Abstract;
public interface ICategoryService
{
    Task<List<Category>> GetAllAsync();
    Task AddCategory(Category category);
    Task RemoveCategory(Category category);
}
