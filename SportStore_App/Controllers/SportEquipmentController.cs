using SportStore_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStore_App.Controllers
{
    public class SportEquipmentController : Controller
    {
        public static string connString = "Data Source=LAPTOP-P4F5KURV;Initial Catalog=SportStoreDB;Integrated Security=True;Pooling=False";
        public static SportStoreDContextDataContext myDataContext = new SportStoreDContextDataContext();

        // GET: SportEquipment
        public ActionResult AllEquipments()
        {
            return View(myDataContext.SportEquipments.ToList());
        }
        public ActionResult EquipmentTable()
        {
            return View(myDataContext.SportEquipments.ToList());
        }
        public ActionResult OnlyFootball()
        {
            return View(myDataContext.SportEquipments.Where(item => item.WhatSport == "Football").ToList());
        }
        public ActionResult OnlyBasketBall()
        {
            return View(myDataContext.SportEquipments.Where(item => item.WhatSport == "BasketBall").ToList());

        }
        public ActionResult PriceSortedEquipments()
        {
            return View(myDataContext.SportEquipments.OrderBy(equip => equip.Price).ToList());
        }
    }
}