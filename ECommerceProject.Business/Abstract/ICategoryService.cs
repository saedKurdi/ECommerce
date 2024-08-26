using ECommerceProject.Entities.Models;
namespace ECommerceProject.Business.Abstract;
public interface ICategoryService
{
    Task<List<Category>> GetAllAsync();
}
