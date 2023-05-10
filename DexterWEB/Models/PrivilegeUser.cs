using System;
using System.Collections.Generic;

namespace DexterWEB.Models;

public partial class PrivilegeUser
{
    public int IdPrivilegeUsers { get; set; }

    public int? IdProvolege { get; set; }

    public string? LoginUser { get; set; }

    public virtual Privilege? IdProvolegeNavigation { get; set; }

    public virtual User? LoginUserNavigation { get; set; }
}
