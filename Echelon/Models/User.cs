using System;
using System.Collections.Generic;

namespace Echelon.Models;

public partial class User
{
    public int Uid { get; set; }

    public string? UserName { get; set; }

    public string Password { get; set; } = null!;

    public string? Name { get; set; }

    public string? Role { get; set; }
}
