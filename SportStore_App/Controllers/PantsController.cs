using SportStore_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStore_App.Controllers
{
    public class PantsController : Controller
    {
        // GET: Pants
        public string stringConn = "Data Source=LAPTOP-P4F5KURV;Initial Catalog=SportStoreDB;Integrated Security=True;Pooling=False00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
        public static SportStoreDContextDataContext myDataContext = new SportStoreDContextDataContext();
        // GET: Pantss
        public ActionResult AllPants()
        {
            List<Clothe> OnlyPants = myDataContext.Clothes.Where(item => item.ClothType == "Pants").ToList();
            return View(OnlyPants);
        }
        public ActionResult PantsTable()
        {
            List<Clothe> pantsList = myDataContext.Clothes.Where(item => item.ClothType == "Pants").ToList();

            return View(pantsList);
        }

        public ActionResult OnlyLongPants()
        {
            List<Clothe> LongPantsList = myDataContext.Clothes.Where(item => item.ClothType == "Pants" && item.isShort == false).ToList();
            return View(LongPantsList);
        }

        public ActionResult OnlyDrifitPants()
        {
            List<Clothe> DrifitPants = myDataContext.Clothes.Where(item => item.ClothType == "Pants" && item.isDrifit == true).ToList();
            return View(DrifitPants);
        }
        public ActionResult PriceSortedPants()
        {
            List<Clothe> PantsList = myDataContext.Clothes.Where(item => item.ClothType == "Pants").OrderBy(item => item.Price).ToList();
            return View(PantsList);
        }
    }
}