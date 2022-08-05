using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KChat.Models
{
    public struct Posision
    {
        /// <summary>
        /// X座標最大値
        /// </summary>
        const float MAX_X = 100;//(仮)
        /// <summary>
        /// Y座標最大値
        /// </summary>
        const float MAX_Y = 100;
        /// <summary>
        /// X座標
        /// </summary>
        public float X { get; private set; }
        /// <summary>
        /// Y座標
        /// </summary>
        public float Y { get; private set; }
        /// <summary>
        /// ポジションの設定変更
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetPosiSion(float x,float y)
        {
            this.X = Math.Min(x, MAX_X);//最大値でストップ
            this.Y = Math.Min(x, MAX_Y);
        }
    }
}
