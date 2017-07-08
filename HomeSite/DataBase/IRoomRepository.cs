using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HomeSite.Models;

namespace HomeSite.DataBase
{
    public interface IRoomRepository
    {
        IQueryable<Room> Rooms { get; }
        bool CreateRoom(Room instance);
        bool UpdateRoom(Room instance);
        bool RemoveRoom(Room instance);
    }
}