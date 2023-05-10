using System;
using System.Collections.Generic;

namespace DexterWEB.Models;

public partial class User
{
    public User() { }
    public User(string Login, string Password, string Email, byte[] avatar) 
    {
        this.LoginOfUser = Login;
        this.PasswordOfUser = Password;
        this.Email = Email;
        this.NameOfUser = Login;
        this.Balance = 0;
        this.Avatar = avatar;
    }
    public string LoginOfUser { get; set; } = null!;

    public string PasswordOfUser { get; set; } = null!;

    public string NameOfUser { get; set; } = null!;

    public string? Email { get; set; }

    public string? Telephone { get; set; }

    public string? Passport { get; set; }

    public string? AddressOfUser { get; set; }

    public string? Inn { get; set; }

    public string? BankCard { get; set; }

    public int? Balance { get; set; }

    public string? DescriptionOfUser { get; set; }

    public byte[]? Avatar { get; set; }

    public int? IdHistoryOfUser { get; set; }

    public virtual HistoryOfUser? IdHistoryOfUserNavigation { get; set; }

    public virtual ICollection<PrivilegeUser> PrivilegeUsers { get; set; } = new List<PrivilegeUser>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
