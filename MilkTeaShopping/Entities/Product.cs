using System;
using System.Collections.Generic;

namespace MilkTeaShopping.Entities;

public partial class Product
{
    public Guid ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int Price { get; set; }

    public string? Image { get; set; }

    public bool Status { get; set; }

    public Guid CategoryId { get; set; }

    public string? Username { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual Account? UsernameNavigation { get; set; }
}
