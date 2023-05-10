using System;
using System.Collections.Generic;

namespace DexterWEB.Models;

public partial class TypesOfProduct
{
    public int IdType { get; set; }

    public string NameOfType { get; set; } = null!;

    public virtual ICollection<TypesProduct> TypesProducts { get; set; } = new List<TypesProduct>();
}
