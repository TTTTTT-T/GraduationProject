using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Recipe_network.Models;
namespace Recipe_network.Controllers
{
    public class RecipeShowController : Controller
    {
        ChowhoundNetEntities11 db = new ChowhoundNetEntities11();
        // GET: RecipeShow
        public ActionResult Index(int id)//传进来菜谱的id
        {
            Session["mid"] = id;
            Menuinformation me = db.Menuinformation.Find(id);
            List<BuImage> BuImage = db.BuImage.Where(x => x.MenuinformationID == me.MenuinformationID).ToList();
            List<UserInfo> user = db.UserInfo.Where(p => p.userID == me.userID).ToList();
            ViewBag.BuImage = BuImage;
            ViewBag.users = user;
            ViewBag.comment = db.CommentMenu.Where(p => p.MenuinformationID == id).Count();
            List<CommentMenu> list = db.CommentMenu.Where(p => p.MenuinformationID== id).ToList();
           ViewBag.types= db.Typetypes.ToList();
            ViewBag.us = db.UserInfo.ToList();
            ViewBag.list = db.Menuinformation.Where(x => x.MenuinformationID == id).ToList();//菜谱信息集合
            ViewBag.list4 = db.Menuinformation.OrderByDescending(p => p.MenuinformationID).Take(3).ToList();//热门菜谱
            var typeid = 0;
            foreach (var item in ViewBag.list as List<Menuinformation>)
            {
                typeid = (int)item.TypetID;
            }
            ViewBag.lists = db.Menuinformation.Where(p => p.TypetID == typeid).OrderByDescending(p=>p.MenuinformationID).Take(3).ToList();
            return View(list);
        }
     
        public ActionResult FindAllss(string search,string name)//
        {
           
                Typetypes Typetypes = db.Typetypes.Find(name);
                ViewBag.searchName = db.Menuinformation.Where(p => p.MenuinformationName.Contains(search)).ToList();
            
           
           
            ViewBag.list5 = db.Typetypes.ToList();
          
          
            return View();

        }

        public ActionResult commentAdd(string contents,CommentMenu com)//评论
        {

            try
            {
                    int jj = (int)Session["id"];
                    com.userID = jj;
                    com.MenuinformationID = (int)Session["mid"];
                    int Mid = (int)Session["mid"];
                com.commenttime= DateTime.Now.ToLocalTime().ToString();

                com.contentss = contents;
                    db.CommentMenu.Add(com);
                    db.SaveChanges();
                    int id = (int)Session["mid"];
                return Content("<script>window.location.href='/RecipeShow/Index/"+id+"';</script>");
              
            }
            catch (Exception)
            {

                return RedirectToAction("Index","Login");
            }
                     


        }
    }
}