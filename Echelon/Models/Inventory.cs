using System;
using System.Collections.Generic;

namespace Echelon.Models;

public partial class Inventory
{
    public int Id { get; set; }

    public int? SerialNo { get; set; }

    public string? ProductName { get; set; }

    public int? CostPrice { get; set; }

    public int? SellPrice { get; set; }

    public int? Discount { get; set; }

    public int? Profit { get; set; }
}
