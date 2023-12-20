using System;
using System.Collections.Generic;

namespace MilkTeaShopping.Entities;

public partial class Account
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Token { get; set; }

    public bool Status { get; set; }

    public Guid Roleid { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual Role Role { get; set; } = null!;
}
