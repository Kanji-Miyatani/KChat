using KChat.Service.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KChat.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            var userName=HttpContext.Session.GetString(GlobalConstants.SESSION_KEY_USERNAME);
            ViewData["UserName"] = userName;
            return View();
        }
    }
}
