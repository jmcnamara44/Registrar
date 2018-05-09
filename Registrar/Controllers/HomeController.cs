using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using RegistrarApp.Models;

namespace RegistrarApp.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
