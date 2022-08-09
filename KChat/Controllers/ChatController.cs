using KChat.Models;
using KChat.Models.ChatRoom;
using KChat.Models.RoomSelect;
using KChat.Repository;
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
        [HttpGet]
        public IActionResult Index()
        {
            var userName = HttpContext.Session.GetString(GlobalConstants.SESSION_KEY_USERNAME);
            ViewData["UserName"] = userName;
            CharactorRepository charactorRepository = new CharactorRepository();
            RoomSelectViewModel vm = new RoomSelectViewModel()
            {
                CharactorList = charactorRepository.FetchAll(),
                SelectedCharactorID="",
                SelectedRoomName = ""
                
            };
            return View(vm);
        }
        /// <summary>
        /// ルーム選択画面(HttpPost)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(RoomSelectViewModel vm)
        {
            if (vm.SelectedRoomName == null || vm.SelectedCharactorID == null)
            {
                return RedirectToAction();
            }
            TempData[GlobalConstants.TEMPDATA_KEY_CHARACTOR_ID] = vm.SelectedCharactorID;
            return RedirectToAction("MainRoom", "Chat",new { RoomID = vm.SelectedRoomName });
        }
        /// <summary>
        /// Chat
        /// </summary>
        /// <param name="name"></param>
        /// <param name="roomName"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult MainRoom(string RoomID = "")//←Getのパラメータは大文字始まり
        {
            //===================================
            //基本的にルーム選択画面からのリダイレクトのみ受け付ける。
            //ユーザー名：セッションから取得
            //キャラクタータイプ：URLに含めたくないので、TempData使用(Nullの場合既定キャラで対応)
            //部屋名：URLに含めたいので、routeValueから部屋名取得
            //他ユーザー：どう取得しましょうか、うんこうんこ
            //===================================
            var charaCterTypeID =TempData[GlobalConstants.TEMPDATA_KEY_CHARACTOR_ID]?.ToString();
            if(String.IsNullOrEmpty(RoomID)) return NotFound();
            var roomRepository = new RoomsRepository();
            var room = roomRepository.FetchAll().Where(x => x.RoomID == RoomID).Single();
            var thisUser = new User()
            {
                ID = HttpContext.Session.GetString(GlobalConstants.SESSION_KEY_USERID),
                Name = HttpContext.Session.GetString(GlobalConstants.SESSION_KEY_USERNAME),
                Room = roomRepository.FetchAll().Where(x=>x.RoomID== RoomID).Single(),
                Posision = new Posision(),
                Character = new Character("kawaii","かわいい"),
            };
            //他ユーザ取得処理（未実装）
            var otherUsers = new List<User>();

            var vm = new ChatRoomViewModel()
            {
                ThisUser = thisUser,
                Users = otherUsers,
                RoomName = room.RoomName

            };
            return View(vm);

        }

    }
}
