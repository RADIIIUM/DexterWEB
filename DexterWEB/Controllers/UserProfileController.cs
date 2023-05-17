using DexterWEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.Identity.Client;

namespace DexterWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        [HttpPost("updatepassword")]
        public async Task<ActionResult> UpdatePassword(PasswordString Password)
        {
            if (string.IsNullOrEmpty(Password.Password))
            {
                return BadRequest();
            }
            else
            {
                using (DexterContext db = new DexterContext())
                {
                    User user = db.Users.FirstOrDefault(x => x.LoginOfUser == Initial.Login);
                    user.PasswordOfUser = Password.Password;
                    await db.SaveChangesAsync();
                    return Ok();
                }
            }
        }

            [HttpPost("userupdate")]
        public async Task<ActionResult> UserUpdate(UserOptions us)
        {
            if(us == null || us.Name == null)
            {
                return BadRequest();
            }
            else
            {
                using(DexterContext db = new DexterContext())
                {
                    User user = db.Users.FirstOrDefault(x => x.LoginOfUser == Initial.Login);
                    user.NameOfUser = (us.Name == null ? user.NameOfUser : us.Name);
                    user.Telephone = us.Telephone;
                    user.Email = us.Email;
                    user.BankCard = us.BankCard;
                    user.AddressOfUser = us.Address;
                    user.Passport = us.Passport;
                    user.Inn = us.INN;
                    await db.SaveChangesAsync();
                    return Ok();
                }
            }
        }
    }
    public class UserOptions
        {
        public UserOptions(string Name, string BankCard, string Telephone, string Address, string Passport, string Email, string INN)
        {
            this.Name = Name;
            this.BankCard = BankCard;
            this.Telephone = Telephone;
            this.Address = Address;
            this.Passport = Passport;
            this.Email = Email;
            this.INN = INN;
        }
        public UserOptions()
        {

        }
        public string Name { get; set; }
        public string? BankCard { get; set; }
        public string? Telephone { get; set; }
        public string? Address { get; set; }
        public string? Passport { get; set; }
        public string? Email { get; set; }

        public string? INN { get; set; }

    }

    }

public class PasswordString
{
    public PasswordString()
    {

    }

    public PasswordString(string Password)
    {
        this.Password = Password;
    }

    public string Password { get; set; }
}

