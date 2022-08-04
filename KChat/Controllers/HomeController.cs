using KChat.Models;
using KChat.Service.Constants;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KChat.Controllers
{
    /// <remarks>
    /// <see cref="AllowAnonymous"/> この属性は Cookie 認証していなくてもアクセスできる Action (Controller) であることを示す。
    /// </remarks>
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        /// <summary>
        /// 使えない名前
        /// </summary>
        private readonly Dictionary<int,string> CANNOTUSE_NAMES = new Dictionary<int,string>()
        {
            { 1,"カンジ"},{ 2,"かつや"}
        };
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// 開始画面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// クッキー認証情報に名前追加
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Index(string user_name)
        {
            if (String.IsNullOrWhiteSpace(user_name))
            {
                ViewData["Error"] = "名前が入力されていません。";
                return View();
            }
            if (CANNOTUSE_NAMES.Any(x => x.Value == user_name))
            {
                ViewData["Error"] = "この名前は、お前ごときじゃ、使えない。";
                return View();
            }
            // サインインに必要なプリンシパルを作る
            var claims = new[] { new Claim(ClaimTypes.Name, user_name) };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            //セッションにログイン中のID,追加。
            int userCount=HttpContext.Session.Keys.Count();
            HttpContext.Session.SetString(GlobalConstants.SESSION_KEY_USERID,$"user_{userCount}");
            HttpContext.Session.SetString(GlobalConstants.SESSION_KEY_USERID, user_name);


            //レスポンスに認証用Cookie追加
            await HttpContext.SignInAsync(principal);
            //ルーム選択画面へ
            return RedirectToAction("Index","Chat");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
