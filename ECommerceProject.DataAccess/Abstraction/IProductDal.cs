using ECommerceProject.Core.DataAccess;
using ECommerceProject.Entities.Models;
namespace ECommerceProject.DataAccess.Abstraction;
public interface IProductDal : IEntityRepository<Product>
{
}
