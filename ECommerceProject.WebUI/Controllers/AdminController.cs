using ECommerceProject.Business.Abstract;
using ECommerceProject.Entities.Models;
using ECommerceProject.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
namespace ECommerceProject.WebUI.Controllers;
public class AdminController : Controller
{
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public AdminController(IProductService productService,ICategoryService categoryService)
    {
        _productService = productService;
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> Index(int page = 1, int category = 0, string filterName = "", string filterPrice = "")
    {
        var items = await _productService.GetAllByCategoryAsync(category);
        int pageSize = 10;

        bool e1 = filterName == "a-z" ? true : false;
        bool e2 = filterPrice == "lower" ? true : false;
        var model = new ProductListViewModel
        {
            Products = items.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
            PageSize = pageSize,
            CurrentCategory = category,
            CurrentPage = page,
            PageCount = (int)Math.Ceiling(items.Count / (double)pageSize),
            FilterByName = filterName,
            FilterByPrice = filterPrice,
            IsAdmin = true,
        };
        if (!filterName.IsNullOrEmpty()) { model.FilterByPrice = ""; model.Products = (e1 == true ? model.Products.OrderBy(p => p.ProductName).ToList() : model.Products.OrderByDescending(p => p.ProductName).ToList()); }
        if (!filterPrice.IsNullOrEmpty()) { model.FilterByName = ""; model.Products = (e2 == true ? model.Products.OrderBy(p => p.UnitPrice).ToList() : model.Products.OrderByDescending(p => p.UnitPrice).ToList()); }
        return View(model);
    }

    public async Task<IActionResult> AddCategory(string categoryName)
    {
        var categories = await _categoryService.GetAllAsync();
        var count = categories.Count;
        var newCategory = new Category { CategoryId = count + 1, CategoryName = categoryName, Description = "", Products = new List<Product>() { } ,Picture = new byte[5]};
        await _categoryService.AddCategory(newCategory);
        return RedirectToAction("Index","Admin");
    }

    public async Task<IActionResult> RemoveCategory(int categoryId)
    {
        var categories = await _categoryService.GetAllAsync();
        var c = categories.FirstOrDefault(c => c.CategoryId == categoryId);
        await _categoryService.RemoveCategory(c);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> RemoveProduct(int productId)
    {
        await _productService.DeleteAsync(productId);
        return RedirectToAction("Index");
    }

    public IActionResult AddProduct()
    {
        var model = new AddProductViewModel
        {
            Product = new Product()
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(AddProductViewModel model)
    {
        if (ModelState.IsValid) {
            await _productService.AddAsync(model.Product);
        }
        return RedirectToAction("Index");
    }
}
