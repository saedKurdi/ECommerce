using ECommerceProject.Business.Abstract;
using ECommerceProject.Entities.Concrete;
using ECommerceProject.WebUI.Models;
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

    public IActionResult List()
    {
        var cart = _cartSessionService.GetCart();
        var model = new CartListViewModel { Cart = cart};
        return View(model);
    }

    public async Task<IActionResult> Remove(int productId)
    {
        var cart = _cartSessionService.GetCart();
        var product = await _productService.GetByIdAsync(productId);
        _cartService.RemoveFromCart(cart, productId);
        _cartSessionService.SetCart(cart);
        TempData.Add("message", $"Your product '{product.ProductName}' has been removed successfully from cart !");
        return RedirectToAction("List");
    }

    [HttpGet]
    public IActionResult Complete()
    {
        var shippingDetailViewModel = new ShippingDetailViewModel { 
            ShippingDetails = new ShippingDetails()
        };
        return View(shippingDetailViewModel);
    }

    [HttpPost]
    public IActionResult Complete(ShippingDetailViewModel shippingDetailViewModel)
    {
        if (!ModelState.IsValid) return View(shippingDetailViewModel);
        TempData.Add("message", String.Format("Thank you {0} , your order is in progress ...",shippingDetailViewModel.ShippingDetails.Firstname +  " " + shippingDetailViewModel.ShippingDetails.Lastname));
        return RedirectToAction("List");
    }

    [HttpPost]
    public IActionResult Decrease(int productId)
    {
        var cart = _cartSessionService.GetCart();
        _cartService.DecreaseFromCart(cart, productId);
        _cartSessionService.SetCart(cart); 
        return RedirectToAction("List");
    }

    [HttpPost]
    public IActionResult Increase(int productId)
    {
        var cart = _cartSessionService.GetCart();
        _cartService.IncreaseFromCart(cart, productId);
        _cartSessionService.SetCart(cart);
        return RedirectToAction("List");
    }

    [HttpGet]
    public IActionResult RemoveAll()
    {
        var cart = _cartSessionService.GetCart();
        _cartService.RemoveAllItemsFromCart(cart);
        _cartSessionService.SetCart(cart);
        return RedirectToAction("List");
    }
}       
