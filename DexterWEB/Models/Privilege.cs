using System;
using System.Collections.Generic;

namespace DexterWEB.Models;

public partial class Privilege
{
    public int IdStatus { get; set; }

    public string NameOfStatus { get; set; } = null!;

    public virtual ICollection<PrivilegeUser> PrivilegeUsers { get; set; } = new List<PrivilegeUser>();
}
