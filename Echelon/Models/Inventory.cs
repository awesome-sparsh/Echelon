using System;
using System.Collections.Generic;

namespace Echelon.Models;

public partial class Inventory
{
    public int Id { get; set; }

    public string? SerialNo { get; set; }

    public string? ProductName { get; set; }

    public string? ManufacturerCode { get; set; }

    public int? Quantity { get; set; }

    public string? PurchaseFrom { get; set; }

    public int? PurchasePrice { get; set; }
}
