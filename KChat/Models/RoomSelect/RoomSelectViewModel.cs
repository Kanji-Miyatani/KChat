using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KChat.Models.RoomSelect
{
    public class RoomSelectViewModel
    {
        public string SelectedRoomName { get; set; }

        public string SelectedCharactorID { get; set; } = "kawaii";//仮

        public List<Character> CharactorList { get; set; } //お疲れさん//こん
    }
}
