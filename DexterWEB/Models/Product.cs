using System;
using System.Collections.Generic;

namespace DexterWEB.Models;

public partial class Product
{
    public int IdProduct { get; set; }

    public string NameOfProduct { get; set; } = null!;

    public byte[]? AvatarOfProduct { get; set; }

    public int? ImagesOfProduct { get; set; }

    public int Price { get; set; }

    public int? Comments { get; set; }

    public string? DescriptionOfProduct { get; set; }

    public string? Specifications { get; set; }

    public bool? Fix { get; set; }

    public int? Discount { get; set; }

    public virtual Comment? CommentsNavigation { get; set; }

    public virtual ImagesOfProduct? ImagesOfProductNavigation { get; set; }

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();

    public virtual ICollection<TypesProduct> TypesProducts { get; set; } = new List<TypesProduct>();

    public virtual ICollection<Warehouse> Warehouses { get; set; } = new List<Warehouse>();
}
