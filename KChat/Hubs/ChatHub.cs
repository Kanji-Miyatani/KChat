using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KChat.Hubs
{
    public class ChatHub:Hub
    {
        public async Task SendMessage(string user, string message)　//全体に向けてメッセージ送信（管理者からのメッセージとかで使うとおもしろいかも）
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task SendMessageToGroup(string group, string user, string message)//グループに向けてメッセージ送信
        {
            await Clients.Group(group).SendAsync("ReceiveMessage", user, message);
        }

        public async Task AddToGroup(string groupName)  //グループに追加する処理
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }
    }
}
