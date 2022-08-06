using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KChat.Models
{
    /// <summary>
    /// ユーザー情報
    /// </summary>
    public class User
    {
        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 識別ID
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 入室中のRoom
        /// </summary>
        public Room Room { get; set; }
        /// <summary>
        /// キャラクター情報
        /// </summary>
        public Character Character { get; set; }
        /// <summary>
        /// 位置情報
        /// </summary>
        public Posision Posision { get; set; }
        /// <summary>
        /// 入室有無
        /// </summary>
        public bool FlagEntry
        {
            get 
            {
                return Room != null;
            }
        }
    }
}
