﻿using ECommerceProject.Core.Abstraction;

namespace ECommerceProject.Entities.Models;

public partial class Category : IEntity
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public byte[]? Picture { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
