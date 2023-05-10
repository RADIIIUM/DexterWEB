
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
        [HttpPost("[action]")]
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
                ViewBag.Image = imageData;
                return View("~/Views/Home/RegistrationWindow.cshtml", model: file);
            }
            return View("~/Views/Home/RegistrationWindow.cshtml");
        }
        [HttpPost("[action]")]
        public async Task<ActionResult> CreateUser([FromForm] UsersViewModel uvm)
        {
            using (DexterContext db = new DexterContext())
            {
                    User person = new User(uvm.Login, uvm.Password, uvm.Email, ViewBag.Image);
                    db.Users.Add(person);
                    await db.SaveChangesAsync();
                    return View("~/Views/Home/RegistrationWindow.cshtml");
            }
        }
    }
}
