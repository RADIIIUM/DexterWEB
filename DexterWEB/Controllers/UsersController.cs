
using DexterWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using System.Diagnostics;
using System.IO.Pipelines;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Web;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;

namespace DexterWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        public byte[] avatar;
        [HttpPost("createuser")]
        public async Task<ActionResult<User>> CreateUser(UsersViewModel uv)
        {
            using (DexterContext db = new DexterContext())
            {
                if (uv == null)
                {
                    return BadRequest();
                }
                if (this.avatar == null)
                {
                    this.avatar = System.IO.File.ReadAllBytes(@"C:\Users\Владелец\source\repos\DexterWEB\DexterWEB\wwwroot\other\images\StandartProfile.png");
                }
                User person = new User(uv.Login, uv.Password, uv.Email, this.avatar);
                db.Users.Add(person);
                await db.SaveChangesAsync();
                return Ok(person);
            }
        }
        [HttpPost("unloadavatar")]
        public IActionResult UploadAvatar([FromForm] IFormFile file)
        {
            if (file != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(file.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes(Convert.ToInt32(file.Length));
                }
                // установка массива байтов
                avatar = imageData;
                return View("~/Views/Home/RegistrationWindow", model: file);
            }
            return View("~/Views/Home/RegistrationWindow");
        }
        [HttpGet("{Login}")]
        public async Task<ActionResult> GetUser(string Login)
        {
            using (DexterContext db = new DexterContext())
            {
                try
                {
                    string? user = db.Users.First(x => x.LoginOfUser == Login).LoginOfUser;
                    if (user == null)
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                catch(InvalidOperationException ex)
                {
                    return Ok();
                }

            }
        }
    }
}
