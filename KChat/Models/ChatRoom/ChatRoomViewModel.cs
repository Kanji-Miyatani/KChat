using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KChat.Models.ChatRoom
{
    public class ChatRoomViewModel
    {
        /// <summary>
        /// 部屋名
        /// </summary>
        public string RoomName { get; set; }
        /// <summary>
        /// ユーザー
        /// </summary>
        public User ThisUser { get; set; }
        /// <summary>
        /// 他のユーザー(ThisUserも含めるか？？)
        /// </summary>
        public IEnumerable<User> Users { get; set; }
    }
}
