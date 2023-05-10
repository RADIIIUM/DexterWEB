using System;
using System.Collections.Generic;

namespace DexterWEB.Models;

public partial class TypesProduct
{
    public int IdTp { get; set; }

    public int? IdType { get; set; }

    public int? IdProduct { get; set; }

    public virtual Product? IdProductNavigation { get; set; }

    public virtual TypesOfProduct? IdTypeNavigation { get; set; }
}
