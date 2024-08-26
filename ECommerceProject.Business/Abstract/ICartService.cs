using ECommerceProject.Entities.Concrete;
using ECommerceProject.Entities.Models;

namespace ECommerceProject.Business.Abstract;
public interface ICartService
{
    void AddToCart(Cart cart,Product product);
    List<CartLine> List(Cart cart);
    void RemoveFromCart(Cart cart, int productId);
}
