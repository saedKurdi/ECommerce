using System;
using System.Collections.Generic;

namespace ECommerceProject.Entities.Models;

public partial class ProductsAboveAveragePrice
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }
}
