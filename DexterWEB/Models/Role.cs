using System;
using System.Collections.Generic;

namespace DexterWEB.Models;

public partial class Role
{
    public int IdRole { get; set; }

    public string NameOfRole { get; set; } = null!;

    public string? LoginOfUsers { get; set; }

    public virtual User? LoginOfUsersNavigation { get; set; }
}
