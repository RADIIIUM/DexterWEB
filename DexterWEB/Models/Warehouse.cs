using System;
using System.Collections.Generic;

namespace DexterWEB.Models;

public partial class Warehouse
{
    public int IdCell { get; set; }

    public int? CountOfProduct { get; set; }

    public int? IdProduct { get; set; }

    public virtual Product? IdProductNavigation { get; set; }
}
