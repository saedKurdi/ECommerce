using ECommerceProject.Entities.Models;
namespace ECommerceProject.Business.Abstract;
public interface IProductService
{
    // methods will be implemented in classes : 
    Task<List<Product>> GetAllAsync();
    Task<List<Product>> GetAllByCategoryAsync(int categoryId);
    Task<List<Product>> GetFilteredProductsAsync(int categoryId,string filterName,string filterPrice);
    Task AddAsync(Product product);
    Task UpdateAsync(Product product);
    Task DeleteAsync(int id);
    Task<Product> GetByIdAsync(int id);
}
