using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeSite.Models.Abstract;
using HomeSite.DataBase;
using HomeSite.Models;

namespace HomeSite.DataBase
{
    public class RoomRepository : IRoomList
    {
        private MyDataBase context = new MyDataBase();
        public IQueryable<Room> Rooms
        {
            get { return context.Rooms; }
        }

    }
}