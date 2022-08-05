using KChat.Service.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KChat.Controllers
{
    public class ChatController : Controller
    {
        /// <summary>
        /// ルーム選択画面
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var userName = HttpContext.Session.GetString(GlobalConstants.SESSION_KEY_USERNAME);
            ViewData["UserName"] = userName;
            return View();
        }

        public IActionResult MainRoom(string name)
        {
            if (name == null) return NotFound();
            
            return View();
        }
    }
}
