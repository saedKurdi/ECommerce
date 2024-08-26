using ECommerceProject.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
namespace ECommerceProject.WebUI.ViewComponents;
public class CartSummaryViewComponent : ViewComponent
{
    private readonly ICartSessionService _cartSessionService;
    public CartSummaryViewComponent(ICartSessionService sessionService)
    {
        _cartSessionService = sessionService;
    }

    public ViewViewComponentResult Invoke()
    {
        var model = new CartSummaryViewModel
        {
            Cart = _cartSessionService.GetCart()
        };
        return View(model);
    }
}
