using SportStore_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStore_App.Controllers
{
    public class ShirtsController : Controller
    {
        public string stringConn = "Data Source=LAPTOP-P4F5KURV;Initial Catalog=SportStoreDB;Integrated Security=True;Pooling=False00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
        public static SportStoreDContextDataContext myDataContext = new SportStoreDContextDataContext();
        // GET: Shirts
        public ActionResult AllShirts()
        {
            List<Clothe> OnlyShirts = myDataContext.Clothes.Where(item => item.ClothType == "Shirt").ToList();
            return View(OnlyShirts);
        }
        public ActionResult ShirtsTable()
        {
            List<Clothe> shirtList = myDataContext.Clothes.Where(item => item.ClothType == "Shirt").ToList();
            return View(shirtList);
        }

        public ActionResult OnlyLongShirts()
        {
            List<Clothe> LongShirtsList = myDataContext.Clothes.Where(item => item.isShort == false && item.ClothType =="Shirt").ToList();
            return View(LongShirtsList);
        }

        public ActionResult OnlyDrifit()
        {
            List<Clothe> DrifitShirts = myDataContext.Clothes.Where(item => item.ClothType == "Shirt" && item.isDrifit == true).ToList();
            return View(DrifitShirts);
        }
        public ActionResult PriceSortedShirts()
        {
            List<Clothe> shirtList = myDataContext.Clothes.Where(item => item.ClothType == "Shirt").OrderBy(item=>item.Price).ToList();
            return View(shirtList);
        }
    }
}