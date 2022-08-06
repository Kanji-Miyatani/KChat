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
        #region -----コンストラクタ
        public Character(string charactorID,string charactorName)
        {
            this.CharactertID = charactorID;
            this.CharacterName = charactorName;
        }
       
        #endregion

        #region -----プロパティ
        const string PATH_EXTENSION = ".png"; 
        public string CharactertID { get;private set; }
        public string CharacterName { get; private set; }
        /// <summary>
        /// キャラクターの画像パス
        /// </summary>
        public string CharacterPath
        {
            get 
            {
                return $"/images/{CharactertID}{PATH_EXTENSION}";
            }
        }

        #endregion
    }
  

    
}
