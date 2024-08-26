using ECommerceProject.Entities.Models;

namespace ECommerceProject.Entities.Concrete;
public class CartLine
{
    public Product ? Product { get; set; }
    public int Quantity{ get; set; }
}
