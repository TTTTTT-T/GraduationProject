using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Recipe_network.Models;
namespace Recipe_network.Controllers
{
    public class RecipeHomeController : Controller
    {
        ChowhoundNetEntities11 db = new ChowhoundNetEntities11();
        // GET: RecipeHome
        public ActionResult Index(string search)
        {
            Session["mid"] = "";
            ViewBag.list = db.Menuinformation.Take(5).ToList();
            ViewBag.list1 = db.Menuinformation.Where(x => x.MenuinformationName.Contains(search)||search==null).ToList();
          


            ViewBag.lists = db.Menuinformation.OrderByDescending(p => p.MenuinformationID).Take(3).ToList();

            return View();
        }
        public ActionResult Index1()
        {
            return Content("<script> alert('请先登录'); history.go(-1);</script>");

           
        }
    }
}