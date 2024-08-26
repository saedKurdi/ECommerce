using ECommerceProject.Business.Abstract;
using ECommerceProject.DataAccess.Abstraction;
using ECommerceProject.Entities.Models;

namespace ECommerceProject.Business.Concrete;
public class ProductService : IProductService
{
    private readonly IProductDal productDal;

    public ProductService(IProductDal productDal)
    {
        this.productDal = productDal;
    }
    public async Task AddAsync(Product product)
    {
        await productDal.Add(product);
    }
    public async Task DeleteAsync(int id)
    {
        var item = await productDal.Get(p => p.ProductId == id);
        await productDal.Delete(item);
    }

    public Task<List<Product>> GetAllAsync()
    {
       return productDal.GetList();
    }

    public Task<List<Product>> GetAllByCategoryAsync(int categoryId)
    {
        return productDal.GetList(p => p.CategoryId == categoryId || categoryId == 0);
    }


    public async Task<Product> GetByIdAsync(int id)
    {
        return await productDal.Get(p => p.ProductId == id);
    }

    public async Task<List<Product>> GetFilteredProductsAsync(int categoryId, string filterName, string filterPrice)
    {
       var products = await GetAllByCategoryAsync(categoryId);
        
        // filter by name :
        if (filterName == "a-z")
        {
            products = products.OrderBy(p => p.ProductName).ToList();
        }
        else if (filterName == "z-a")
        {
            products = products.OrderByDescending(p => p.ProductName).ToList();
        }

        // filter by price : 
        if (filterPrice == "lower")
        {
            products = products.OrderBy(p => p.UnitPrice).ToList();
        }
        else if (filterPrice == "higher")
        {
            products = products.OrderByDescending(p => p.UnitPrice).ToList();
        }

        return products;
    }

    public async Task UpdateAsync(Product product)
    {
       await productDal.Update(product);
    }
}
