﻿using DexterWEB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.JSInterop;
using System.Diagnostics;
using System.IO.Pipelines;
using static System.Net.Mime.MediaTypeNames;

namespace DexterWEB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GoToReg()
        {
            return View("RegistrationWindow");
        }

        public IActionResult GoToSign()
        {
            return View("Index");
        }

        [HttpGet]

        public async Task<IActionResult> Autorization(string Login, string Password)
        {
            using (DexterContext db = new DexterContext())
            {
                foreach (var user in db.Users)
                {
                    if (user.LoginOfUser == Login)
                    {
                        if (user.PasswordOfUser == Password)
                        {
                            return Ok();

                        }
                        else
                        {
                            return BadRequest();
                        }
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                return BadRequest();
            }
        }
    }
}