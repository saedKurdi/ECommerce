using ECommerceProject.Business.Abstract;
using ECommerceProject.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
namespace ECommerceProject.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService service)
        {
            _productService = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1,int category = 0,string filterName ="",string filterPrice="")
        {
            var items = await _productService.GetAllByCategoryAsync(category);
            int pageSize = 10;
            

            bool e1 = filterName == "a-z" ? true : false;
            bool e2 = filterPrice == "lower" ? true : false;
            var model = new ProductListViewModel
            {
                Products = items.Skip((page - 1)*pageSize).Take(pageSize).ToList(),
                PageSize = pageSize,
                CurrentCategory = category,
                CurrentPage = page,
                PageCount = (int)Math.Ceiling(items.Count/(double)pageSize),
                FilterByName=filterName,
                FilterByPrice=filterPrice,
            };
            if (!filterName.IsNullOrEmpty()) { model.FilterByPrice = ""; model.Products = (e1 == true ? model.Products.OrderBy(p => p.ProductName).ToList() : model.Products.OrderByDescending(p => p.ProductName).ToList()); }
            if (!filterPrice.IsNullOrEmpty()) { model.FilterByName = ""; model.Products = (e2 == true ? model.Products.OrderBy(p => p.UnitPrice).ToList() : model.Products.OrderByDescending(p => p.UnitPrice).ToList()); }
            return View(model);
        }

        // this method will be called from site.js (www-root) side : 
        [HttpGet]
        public async Task<IActionResult> SearchProducts(string searchTerm,int page=1,int category=0)
        {
            var items =await  _productService.GetAllByCategoryAsync(category);

            // filtering products by search term : 
            if (!string.IsNullOrEmpty(searchTerm)) items = items.Where(p => p.ProductName.StartsWith(searchTerm,StringComparison.OrdinalIgnoreCase)).ToList();
            int pageSize = 10;
            var model = new ProductListViewModel { 
                Products = items.Skip((page-1) * pageSize).Take(pageSize).ToList(),
                PageSize = pageSize,
                CurrentCategory = category,
                CurrentPage = page,
                PageCount = (int)Math.Ceiling(items.Count / (double)pageSize)
            };
            return PartialView("_ProductListPartial", model);  // Return a partial view to dynamically update product list
        }
    }
}
