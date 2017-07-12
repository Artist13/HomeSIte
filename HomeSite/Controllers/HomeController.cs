using System;
using System.IO;
using System.Text;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using HomeSite.Models;
using System.Net.Mail;
using System.Xml;
using Newtonsoft.Json;

namespace HomeSite.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        //
        public ActionResult Entertainment()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Contacts()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contacts(FeedbackForm Form)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress("Registrator@sovetov9.ru");
            message.To.Add(new MailAddress("nikita-podhvatoff@yandex.ru"));
            message.Subject = Form.Them;
            message.Body = Form.Name + '\n' + Form.Email + '\n' + Form.Mes;
            SmtpClient client = new SmtpClient("smtp.yandex.ru");
            client.EnableSsl = true;
            client.Port = 25;

            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("Registrator@sovetov9.ru", "4arpZ0M!");

            try
            {
                client.Send(message);
            }
            catch(SmtpException ex)
            {
                SmtpException tempEx = ex;
            }
            ViewBag.Message = true;
            return View();
        }
        
        public WeatherDate GetWeather()
        {
            string weather_date = "http://api.openweathermap.org/data/2.5/weather?lat=46.716178&lon=38.26780&id=524901&APPID=e49d9ff0bd027efc333242d89221f582&mode=json&lang=ru&units=metric";
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(weather_date);
            string str = req.RequestUri.ToString();
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            var jsonSource = new StreamReader(resp.GetResponseStream(), Encoding.UTF8).ReadToEnd();
            string strin = jsonSource.ToString();
            WeatherDate weather = JsonConvert.DeserializeObject<WeatherDate>(jsonSource);
            return weather;
        }
        public ActionResult Weather()
        {
            //if (DateTime.Now.Subtract(weather._lastUpdate).TotalMinutes > 30)
            WeatherDate weather = GetWeather();
            weather.Main.Temp = weather.Main.Temp.Split('.')[0];
            weather._lastUpdate = DateTime.Now.ToString("D", new CultureInfo("ru-Ru"));
            weather.Weather[0].Icon = "https://openweathermap.org/img/w/" + weather.Weather[0].Icon + ".png";
            return View(weather);
        }
        public ViewResult DatePicker()
        {
            ViewBag.Days = new SelectList(new[]
            {
                new {Id = 1, Reserv = 0 },
                new {Id = 2, Reserv = 0 },
                new {Id = 3, Reserv = 0 },
                new {Id = 4, Reserv = 0 },
                new {Id = 5, Reserv = 0 },
                new {Id = 6, Reserv = 0 },
                new {Id = 7, Reserv = 0 },
                new {Id = 8, Reserv = 0 },
                new {Id = 9, Reserv = 0 },
                new {Id = 10, Reserv = 1 },
                new {Id = 11, Reserv = 1 },
                new {Id = 12, Reserv = 1 },
                new {Id = 13, Reserv = 1 },
                new {Id = 14, Reserv = 1 },
                new {Id = 15, Reserv = 1 },
                new {Id = 16, Reserv = 1 },
                new {Id = 17, Reserv = 1 },
                new {Id = 18, Reserv = 1 },
                new {Id = 19, Reserv = 0 },
                new {Id = 20, Reserv = 0 },
                new {Id = 21, Reserv = 0 },
                new {Id = 22, Reserv = 1 },
                new {Id = 23, Reserv = 1 },
                new {Id = 24, Reserv = 1 },
                new {Id = 25, Reserv = 1 },
                new {Id = 26, Reserv = 1 },
                new {Id = 27, Reserv = 0 },
                new {Id = 28, Reserv = 0 },
                new {Id = 29, Reserv = 0 },
                new {Id = 30, Reserv = 0 },
                new {Id = 31, Reserv = 0 },
            }, "Id", "Reserv");
            return View();
        }
        public JsonResult Month()
        {
            int number = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 0).Day;
            bool[] month = new bool[number];
            return Json(month, JsonRequestBehavior.AllowGet);
        }
    }
}