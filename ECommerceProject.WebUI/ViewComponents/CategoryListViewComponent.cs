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
        // Get the current route data
        var routeData = HttpContext.GetRouteData();

        // Extract the controller and action names from the route data
        var controllerName = routeData.Values["controller"]?.ToString();
        var actionName = routeData.Values["action"]?.ToString();

        var categories = _categoryService.GetAllAsync().Result;
        var param = HttpContext.Request.Query["category"];
        var category = int.TryParse(param, out var categoryId);
        var model = new CategoryListViewModel
        {
            Categories = [new Category { CategoryId = 0, CategoryName = "All Categories", Description = "All" }, .. categories],
            CurrentCategory = category ? categoryId : 0,
            IsAdmin = controllerName == "Admin" || controllerName == "admin"
        };

        return View(model);
    }
}
