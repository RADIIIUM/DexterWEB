using System;
using System.Collections.Generic;

namespace DexterWEB.Models;

public partial class News
{
    public int IdNew { get; set; }

    public string Paragraph { get; set; } = null!;

    public string DescriptionOfNews { get; set; } = null!;

    public byte[]? MainImage { get; set; }

    public bool? Fix { get; set; }
}
