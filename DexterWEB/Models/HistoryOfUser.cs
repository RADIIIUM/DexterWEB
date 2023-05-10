using System;
using System.Collections.Generic;

namespace DexterWEB.Models;

public partial class HistoryOfUser
{
    public int IdHistory { get; set; }

    public DateTime? DateOfAction { get; set; }

    public string? ActionOfUser { get; set; }

    public bool? ReadAction { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
