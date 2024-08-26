using ECommerceProject.Business.Abstract;
using ECommerceProject.Entities.Models;
using ECommerceProject.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
namespace ECommerceProject.WebUI.ViewComponents;
public class CategoryListViewComponent : ViewComponent
{
    private ICategoryService _categoryService;
    public CategoryListViewComponent(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public ViewViewComponentResult Invoke()
    {
        var categories = _categoryService.GetAllAsync().Result;
        var param = HttpContext.Request.Query["category"];
        var category = int.TryParse(param, out var categoryId);
        var model = new CategoryListViewModel
        {
            Categories = [new Category {CategoryId = 0 ,CategoryName="All Categories",Description="All"},..categories],
            CurrentCategory = category ? categoryId : 0,
        };
        return View(model);
    }
}
