using ECommerceProject.Entities.Concrete;

namespace ECommerceProject.WebUI.Services;
public interface ICartSessionService
{
    Cart GetCart();
    void SetCart(Cart cart);
}
