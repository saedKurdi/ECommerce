using ECommerceProject.Core.DataAccess.EntityFramework;
using ECommerceProject.DataAccess.Abstraction;
using ECommerceProject.Entities.Models;

namespace ECommerceProject.DataAccess.Concrete.EFEntityFramework;
public class EFCategoryDal : EFEntityRepositoryBase<Category,NorthwindContext>,ICategoryDal
{
    public EFCategoryDal(NorthwindContext context) : base(context) { }
}
