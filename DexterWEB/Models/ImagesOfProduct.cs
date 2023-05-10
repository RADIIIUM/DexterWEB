using System;
using System.Collections.Generic;

namespace DexterWEB.Models;

public partial class ImagesOfProduct
{
    public int IdImages { get; set; }

    public byte[]? ImageOfProduct { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
