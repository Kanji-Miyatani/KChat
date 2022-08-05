using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KChat.Models
{
    /// <summary>
    /// キャラクター（アバター）
    /// </summary>
    public class Character
    {
        public CharacterType Type { get; set; }

        public string CharactorID { get { return Type.ToString(); } }
    }

    public enum CharacterType
    {
        
    }
}
