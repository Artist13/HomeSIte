using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeSite.Models;

namespace HomeSite.Models.Abstract
{
    public interface IRoomList
    {
        IQueryable<Room> Rooms { get; }
    }
}
