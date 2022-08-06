using KChat.Interfaces;
using KChat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KChat.Repository
{
    public class CharactorRepository : IRepository<Character>
    {
        /// <summary>
        /// 部屋一覧
        /// </summary>
        private List<Character> CharaDB = new List<Character>()
        {
            new Character("kawaii","かわいい")
          
        };
        public IQueryable<Character> Query => throw new NotImplementedException();

        public void Add(Character entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Character entity)
        {
            throw new NotImplementedException();
        }

        public List<Character> FetchAll()
        {
            return CharaDB;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
