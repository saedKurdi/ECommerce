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
    }
}
