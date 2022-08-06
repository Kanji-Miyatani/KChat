using KChat.Interfaces;
using KChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KChat.Repository
{
    /// <summary>
    /// 本来DBで管理すべきだけどソースにルームも埋め込む
    /// </summary>
    public class RoomsRepository : IRepository<Room>
    {
        /// <summary>
        /// 部屋一覧
        /// </summary>
        private List<Room> RoomDB = new List<Room>()
        {
            new Room()
            {
                RoomID ="MainRoom",
                RoomName ="メインルーム"
            }
        };

        public IQueryable<Room> Query => throw new NotImplementedException();

        public void Add(Room entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Room entity)
        {
            throw new NotImplementedException();
        }

        public List<Room> FetchAll()
        {
            return RoomDB;
        }
        public Room FetchFirst(string id)
        {
            return RoomDB.Where(x=>x.RoomID==id).First();
        }
        public void Save()
        {
            throw new NotImplementedException();
        }
    }

    
}
