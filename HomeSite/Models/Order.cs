using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeSite.Models
{
    public class Order
    {
        public int orderID { get; set; }
        public int roomID { get; set; }
        public string incoming { get; set; }
        public string outcoming { get; set; }
        public int persons { get; set; }
        public string autor { get; set; }
        public string registrate { get; set; }
        public void replace(Order temp)
        {
            roomID = temp.roomID;
            incoming = temp.incoming;
            outcoming = temp.outcoming;
            persons = temp.persons;
            autor = temp.autor;
            registrate = temp.registrate;
        }
    }
}