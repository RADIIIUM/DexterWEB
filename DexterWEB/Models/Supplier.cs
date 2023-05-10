using System;
using System.Collections.Generic;

namespace DexterWEB.Models;

public partial class Supplier
{
    public int IdSupplier { get; set; }

    public string NameOfSupplier { get; set; } = null!;

    public int? IdProduct { get; set; }

    public virtual Product? IdProductNavigation { get; set; }
}
