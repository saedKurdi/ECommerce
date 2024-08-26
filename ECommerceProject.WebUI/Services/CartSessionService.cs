using ECommerceProject.Entities.Concrete;
using ECommerceProject.WebUI.Consts;
using ECommerceProject.WebUI.Extensions;
namespace ECommerceProject.WebUI.Services;
public class CartSessionService : ICartSessionService
{
    private IHttpContextAccessor _contextAccessor;

    public CartSessionService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }
    public Cart GetCart()
    {
        Cart cartToCheck = _contextAccessor.HttpContext.Session.GetObject<Cart>(WebUIConstants.CartName);
        if (cartToCheck == null)
        {
            _contextAccessor.HttpContext.Session.SetObject(WebUIConstants.CartName, new Cart());
            cartToCheck = _contextAccessor.HttpContext.Session.GetObject<Cart>(WebUIConstants.CartName);
        }
        return cartToCheck;
    }

    public void SetCart(Cart cart)
    {
        _contextAccessor.HttpContext.Session.SetObject(WebUIConstants.CartName, cart);
    }
}
