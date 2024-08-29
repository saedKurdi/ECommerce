using ECommerceProject.Entities.Models;

namespace ECommerceProject.WebUI.Models;
public class CategoryListViewModel
{
    public List<Category> ? Categories { get; set; }
    public int CurrentCategory { get; set; }
    public bool IsAdmin { get; set; }
}