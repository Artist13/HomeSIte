using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeSite.Models;
using HomeSite.Models.Abstract;
using HomeSite.Models.Auth;
using HomeSite.DataBase;

namespace HomeSite.Controllers
{
    public class AdminController : Controller
    {
        CustomAuthentication auth = new CustomAuthentication();
        MyDataBase db = new MyDataBase();
        Admin CurrentAdmin = new Models.Admin();
        //[HttpGet]
        //public ActionResult Admin()
        //{
        //    return RedirectToAction("Login");
        //}
        
        public ActionResult Admin(string login, string pass)
        {
            auth.Login(login, pass, false);
            if (auth.CurrentAdmin.Login == null)
                return RedirectToAction("Login");
            return View();
        }
        public ActionResult Check(string login, string pass)
        {
            Admin temp = auth.Login(login, pass, false);
            return RedirectToAction("Admin");
           
        }
        [HttpGet]
        public ActionResult Login()
        {
            //if(CurrentAdmin == null)
            if(auth.CurrentAdmin.Login == null)
            {
                return View(CurrentAdmin);
            }
            return RedirectToAction("Admin");
            //return RedirectToAction("Admin");
        }
        public ActionResult LogOut()
        {
            CurrentAdmin = null;
            auth.LogOut();
            return RedirectToAction("Login");
        }
        public ViewResult ListRooms()
        {
            return View(db.Rooms);
        }
        public ViewResult ListOrders()
        {
            return View(db.Orders);
        }
        public ActionResult DeleteRoom(string id)
        {
            int Id = Int32.Parse(id);
            db.Rooms.Remove(db.Rooms.FirstOrDefault(x => x.roomID == Id));
            db.SaveChanges();
            return RedirectToAction("Admin");
        }
        public ActionResult EditRoom(string id)
        {
            int Id = Int32.Parse(id);
            Room temp = db.Rooms.FirstOrDefault(x => x.roomID == Id);
            return View(temp);
        }
        public ActionResult SaveRoom(Room room)
        {
            db.Rooms.FirstOrDefault(x => x.roomID == room.roomID).replace(room);
            db.SaveChanges();
            return RedirectToAction("Admin");
        }
        public ActionResult ConfirmOrder(string id)
        {
            int Id = Int32.Parse(id);
            db.Orders.FirstOrDefault(x => x.orderID == Id).registrate = "1";
            db.SaveChanges();
            return RedirectToAction("Admin");
        }
        public ActionResult DeleteOrder(string id)
        {
            int Id = Int32.Parse(id);
            db.Orders.Remove(db.Orders.FirstOrDefault(x => x.orderID == Id));
            db.SaveChanges();
            return RedirectToAction("Admin");
        }
        public ActionResult EditOrder(string id)
        {
            int Id = Int32.Parse(id);
            Order temp = db.Orders.FirstOrDefault(x => x.orderID == Id);
            return View(temp);
        }
        public ActionResult SaveOrder(Order order)
        {
            db.Orders.FirstOrDefault(x => x.orderID == order.orderID).replace(order);
            db.SaveChanges();
            return RedirectToAction("Admin");

        }
    }
}