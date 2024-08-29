using ECommerceProject.Business.Abstract;
using ECommerceProject.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
namespace ECommerceProject.WebUI.Controllers;
public class CartController : Controller
{
    // private readonly fields for injecting : 
    private readonly ICartService _cartService;
    private readonly IProductService _productService;
    private readonly ICartSessionService _cartSessionService;

    // parametric constructor :
    public CartController(ICartService cartService, IProductService productService, ICartSessionService cartSessionService)
    {
        _cartService = cartService;
        _productService = productService;
        _cartSessionService = cartSessionService;
    }

    public async Task<IActionResult> AddToCart(int productId,int page,int category)
    {
        var productToBeAdded= await _productService.GetByIdAsync(productId);
        var cart = _cartSessionService.GetCart();

        _cartService.AddToCart(cart, productToBeAdded);
        _cartSessionService.SetCart(cart);

        TempData.Add("message", String.Format("Your product {0} was added succesfully !",productToBeAdded.ProductName));
        return RedirectToAction("Index", "Product", new {page=page,category=category});
    }
}
