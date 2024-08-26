using ECommerceProject.Core.DataAccess.EntityFramework;
using ECommerceProject.DataAccess.Abstraction;
using ECommerceProject.Entities.Models;
namespace ECommerceProject.DataAccess.Concrete.EFEntityFramework;
public class EFProductDal : EFEntityRepositoryBase<Product,NorthwindContext>,IProductDal
{
    public EFProductDal(NorthwindContext context) : base(context) { }
}
