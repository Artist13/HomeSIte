using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Moq;
using System.Web.Mvc;
using System.Web.Routing;
using HomeSite.Models.Abstract;
using HomeSite.Models;
using HomeSite.DataBase;
using HomeSite.Models.Auth;

namespace HomeSite.Infrastructure
{
    public class NinjectFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        //protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        //{
        //    return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        //}
        private void AddBindings()
        {
            Mock<IRoomList> mock = new Mock<IRoomList>();
            //mock.Setup(m => m.Rooms).Returns(new List<Room> {
            //    new Room { roomID = "1", Name = "Стандартный1", Beds = new List<string> { "Две односпальные", "Диван" }, Cost = 1000, Size = 2, ImagePath = new List<string> { "room1_1.jpg", "room1_2.jpg", "room1_3.jpg" }, Options = new List<string> {"Кондиционер", "Wi-Fi", "Телевизор" } },
            //    new Room { roomID = "2", Name = "Стандартный2", Beds = new List<string> { "Две односпальные", "Диван" }, Cost = 1000, Size = 2, ImagePath = new List<string> { "room1_1.jpg" }, Options = new List<string> {"Кондиционер", "Wi-Fi", "Телевизор" } }
            //    }.AsQueryable());

            //ninjectKernel.Bind<IRoomList>().ToConstant(mock.Object);
            //ninjectKernel.Bind<IRoomList>().To<RoomRepository>(); // не привязывается хранилище 
            //ninjectKernel.Bind<IAuthentication>().To<CustomAuthentication>().In
        }
    }
}