﻿
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
    public class UsersController : ControllerBase
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
                PrivilegeUser pr = new PrivilegeUser();
                pr.LoginUser = uv.Login;
                pr.IdProvolege = 1;
                Role r = new Role();
                r.LoginOfUsers = uv.Login;
                r.NameOfRole = "Клиент";
                db.Users.Add(person);
                db.Roles.Add(r);
                db.PrivilegeUsers.Add(pr);
                await db.SaveChangesAsync();
                return Ok(person);
            }
        }
        [HttpGet("{Login}&{Password}")]

        public async Task<ActionResult> Autorization(string Login, string Password)
        {
            using (DexterContext db = new DexterContext())
            {
                try
                {
                    string? login = db.Users.First(x => x.LoginOfUser == Login).LoginOfUser;
                    string? password = db.Users.First(x => x.LoginOfUser == Login).PasswordOfUser;
                    if (login != null)
                    {
                        if (password == Password)
                        {
                            Initial.Login = login;
                            return Ok();
                        }
                        else return BadRequest();
                    }
                    else return BadRequest();
                }
                catch(InvalidOperationException ex)
                {
                    return BadRequest();
                }
            }
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
                catch (InvalidOperationException ex)
                {
                    return Ok();
                }

            }
        }
    }
}
