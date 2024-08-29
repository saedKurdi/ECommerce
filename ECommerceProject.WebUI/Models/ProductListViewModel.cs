using ECommerceProject.Entities.Models;

namespace ECommerceProject.WebUI.Models
{
    public class ProductListViewModel
    {
        public List<Product> ? Products { get; set; }
        public int PageSize { get; internal set; }
        public int CurrentCategory { get; internal set; }
        public int PageCount { get; internal set; }
        public int CurrentPage { get; internal set; }
        public string? FilterByName { get; set; }
        public string? FilterByPrice { get; set; } 
        public bool IsAdmin { get; set; }
    }
}