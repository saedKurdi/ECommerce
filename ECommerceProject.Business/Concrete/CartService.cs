using ECommerceProject.Business.Abstract;
using ECommerceProject.Entities.Concrete;
using ECommerceProject.Entities.Models;
namespace ECommerceProject.Business.Concrete;
public class CartService : ICartService
{
    public void AddToCart(Cart cart, Product product)
    {
        CartLine cartLine = cart.CartLines.FirstOrDefault(c => c.Product.ProductId == product.ProductId);
        if (cartLine != null) cartLine.Quantity++;
        else cart.CartLines.Add(new CartLine { Product = product ,Quantity = 1 });
    }

    public void DecreaseFromCart(Cart cart, int productId)
    {
        var cartLine = cart.CartLines.FirstOrDefault(c => c.Product.ProductId == productId);
        cartLine.Quantity-=1;
    }

    public void IncreaseFromCart(Cart cart, int productId)
    {
        var cartLine = cart.CartLines.FirstOrDefault(c => c.Product.ProductId == productId);
        cartLine.Quantity += 1;
    }

    public List<CartLine> List(Cart cart)
    {
        return cart.CartLines;
    }

    public void RemoveAllItemsFromCart(Cart? cart)
    {
        cart.CartLines.RemoveAll(cl => cl.Product != null);
    }

    public void RemoveFromCart(Cart cart, int productId)
    {
       cart.CartLines.Remove(cart.CartLines.FirstOrDefault(c => c.Product.ProductId == productId));
    }
}
