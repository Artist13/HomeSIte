using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeSite.Models;
using HomeSite.Models.Abstract;
using System.Net.Mail;
using System.Net;
using HomeSite.DataBase;


namespace HomeSite.Controllers
{
    public class RoomController : Controller
    {
        public string current_id;
        private IRoomList repository;
        MyDataBase db = new MyDataBase();
        public RoomController()
        { } 
        public RoomController(IRoomList roomRepositoruy)
        {
            this.repository = roomRepositoruy;
        }
        [HttpGet]
        public ActionResult RoomsPrice()
        {
            return View();
        }
        public ViewResult List()
        {
            return View(db.Rooms);
        }
        public ViewResult DatePicker()
        {
            return View();
        }
        public ActionResult GetDate(int month)
        {
            int[] Dates = new int[DateTime.DaysInMonth(DateTime.Now.Year, month+1)];
            for (int i = 0; i < Dates.Length; i++)
            {
                Dates[i] = 0;
            }
            foreach(Order or in db.Orders.Where(x => x.registrate == "Потвержден"))
            {
                string[] inc = or.incoming.Split('-');
                string[] outc = or.outcoming.Split('-');
                int incD = Int32.Parse(inc[2]);
                int incM = Int32.Parse(inc[1]);
                int incY = Int32.Parse(inc[0]);
                int outcD = Int32.Parse(outc[2]);
                int outcM = Int32.Parse(outc[1]);
                int outcY = Int32.Parse(outc[0]);
                if ((incM < month) && (outcM == month))
                {
                    for (int i = 1; i < outcD; i++)
                    {
                        Dates[i - 1] = 1;
                    }
                }
                else if((incM == month) && (outcM == month))
                {
                    for (int i = incD; i < outcD; i++)
                    {
                        Dates[i - 1] = 1;
                    }
                }
                else if((incM == month) && (outcM > month))
                {
                    for (int i = incD; i <= Dates.Length; i++)
                    {
                        Dates[i - 1] = 1;
                    }
                }
                else if((incM < month) && (outcM > month))
                {
                    for (int i = 1; i <= Dates.Length; i++)
                    {
                        Dates[i - 1] = 1;
                    }
                }
            }
            return Json(Dates, JsonRequestBehavior.AllowGet);
        }
        public ViewResult AboutRoom(string id)
        {
            int ID = Int32.Parse(id);
            return View(db.Rooms.First(x => x.roomID == ID));
        }
        public ActionResult AddOrder(string id, string incoming, string outcoming, string person, string tel, string Email)
        {
            int ID = Int32.Parse(id);
            MailMessage message = new MailMessage();
            message.From = new MailAddress("Registrator@sovetov9.ru");
            message.To.Add(new MailAddress("nikita-podhvatoff@yandex.ru"));
            message.Subject = "Бронь";
            message.Body = person + '\n' + Email + '\n' + tel + '\n' + db.Rooms.First(x => x.roomID == ID).Name + '\n' + "Заезд: " + incoming + "Выезд: " + outcoming + '\n' + "Дата подачи: " + DateTime.Now.ToString();
            SmtpClient client = new SmtpClient("mail.sovetov9.ru")
            {
                EnableSsl = false,
                Port = 587,

                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("Registrator@sovetov9.ru", "4arpZ0M!")
            };
           
       
            try
            {
                client.Send(message);
            }
            catch (SmtpException ex)
            {
            }
            if (Email != null)
            {
                message = new MailMessage();
                message.From = new MailAddress("Registrator@sovetov9.ru");
                try
                {
                    message.To.Add(new MailAddress(Email));
                }
                catch
                {
                }
                message.Subject = "Подтверждение бронирования";
                message.Body = "Ваша заявка на бронирование принята. Для подтверждения и уточнения сроков мы свяжемся с вами.";
                try
                {
                    client.Send(message);
                }
                catch 
                {
                }
            }

            
            Order tempOrder = new Order{ roomID = Int32.Parse(id),
                                          incoming = incoming,
                                          outcoming = outcoming,
                                          autor = person,
                                          registrate = "0" };
            db.Orders.Add(tempOrder);
            db.SaveChanges();
            return PartialView();
        }

        public FileContentResult GetImage(string roomName)
        {
            Room room = repository.Rooms.FirstOrDefault(r => r.Name == roomName);
            if(room!=null)
            {
                return null;
            }
            else
            {
                return null;
            }
        }
    }
}