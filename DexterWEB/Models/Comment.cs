using System;
using System.Collections.Generic;

namespace DexterWEB.Models;

public partial class Comment
{
    public int IdComment { get; set; }

    public string? ParagraphOfComment { get; set; }

    public string? DescriptionOfComment { get; set; }

    public string LoginOfUser { get; set; } = null!;

    public int? Rating { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
