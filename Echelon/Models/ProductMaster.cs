using System;
using System.Collections.Generic;

namespace Echelon.Models;

public partial class ProductMaster
{
    public int ProductId { get; set; }

    public string? ManufacturerCode { get; set; }

    public string? ProductName { get; set; }

    public string? Specifications { get; set; }

    public string? PurchasePrice { get; set; }

    public string? ListPrice { get; set; }
}
