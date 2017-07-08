using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using HomeSite.Models;

namespace HomeSite.DataBase
{
    public class SqlRoomRepository : IRoomRepository
    {
        [Inject]
        public MyDataBase Db { get; set; }
        public IQueryable<Room> Rooms
        {
            get { throw new NotImplementedException(); }
        }
        public bool CreateRoom(Room instance)
        {
            throw new NotImplementedException();
        }
        public bool UpdateRoom(Room instance)
        {
            throw new NotImplementedException();
        }
        public bool RemoveRoom(Room instance)
        {
            throw new NotImplementedException();
        }
    }
}