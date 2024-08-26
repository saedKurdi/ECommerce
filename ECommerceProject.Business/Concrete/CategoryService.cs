using ECommerceProject.Business.Abstract;
using ECommerceProject.DataAccess.Abstraction;
using ECommerceProject.Entities.Models;

namespace ECommerceProject.Business.Concrete;
public class CategoryService : ICategoryService
{
    private readonly ICategoryDal _categoryDal;
    public CategoryService(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }
    public async Task<List<Category>> GetAllAsync()
    {
        return await _categoryDal.GetList();
    }
}
