using SportStore_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStore_App.Controllers
{
    public class SportShoesController : Controller
    {
        public string stringConn = "Data Source=LAPTOP-P4F5KURV;Initial Catalog=SportStoreDB;Integrated Security=True;Pooling=False00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000";
        public static SportStoreDContextDataContext myDataContext = new SportStoreDContextDataContext();
        // GET: SportShoes
        
        public ActionResult SportShoeCards()
        {
            List<Shoe> shoesList = myDataContext.Shoes.ToList();
            return View(shoesList);
        }
        public ActionResult ShoesTable()
        {
            List<Shoe> shoesList = myDataContext.Shoes.ToList();
            return View(shoesList);
        }

        public ActionResult ShoesInDiscount()
        {
            List<Shoe> shoesList = myDataContext.Shoes.Where(item=>item.IsSale == true).ToList();
            return View(shoesList);
        }
    }
}