using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeSite.Models
{
    public class Room
    {
        public int roomID { set; get; }
        public string nameImage { set; get; }
        public string Name { set; get; }
        //public List<string> Beds { get; set; }
        public string Beds { get; set; }
        public decimal Cost { set; get; }
        //public List<string> Options { set; get; }
        public string Options { get; set; }
        public int Size { get; set; }
        //public byte[] ImageData { get; set; }
        //public string ImageMimeType { get; set; }
        //public List<string> ImagePath { get; set; }
        public void replace(Room room)
        {
            roomID = room.roomID;
            nameImage = room.nameImage;
            Name = room.Name;
            Beds = room.Beds;
            Cost = room.Cost;
            Options = room.Options;
            Size = room.Size;
        }
    }
}