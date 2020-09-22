using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Recipe_network.Models;
namespace Recipe_network.Controllers
{
    public class UserInfoController : Controller
    {
        ChowhoundNetEntities11 db = new ChowhoundNetEntities11();
        // GET: UserInfo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult shows() //我发布的菜谱
        {
            int id = (int)Session["id"];
             ViewBag.list=db.Menuinformation.Where(p => p.userID == id).ToList();

            return View();
        
        
        }
      
        public ActionResult userInfo(string Uname,string discriptss,string files)
        {
            int id = (int)Session["id"];
            ViewBag.userss = db.UserInfo.Where(p => p.userID == id).ToList();          
            return View();


        }
        
        public ActionResult userInfos(string Uname,string discriptss,string files,HttpPostedFileBase userpic)
        {
            int id = (int)Session["id"];
            ViewBag.userss = db.UserInfo.Where(p => p.userID == id).ToList();
            UserInfo us = db.UserInfo.Find(id);
            if (userpic!=null)
            {

            
            string Filname = Path.GetFileName(userpic.FileName);
            //判断是否为图片
            if (Filname.EndsWith("jpg") || Filname.EndsWith("png") || Filname.EndsWith("gif"))
            {
                //保存到指定位置
                var path = Path.Combine(Server.MapPath("~/images"), Filname);
                userpic.SaveAs(path);
                us.userpic = Filname;
            }
            else
            {
                return Content("<script> alert('上传的图片格式不对')</script>");
            }
            }

            us.discriptss = discriptss;
            us.UName = Uname;
           
            db.SaveChanges();
            Session["UID"] = us;
            return Content("<script> alert('修改成功'); window.location.href='/UserInfo/userInfo';</script>");


        }

        public ActionResult upload()
        {
            int id = (int)Session["id"];
            ViewBag.userss = db.UserInfo.Where(p => p.userID == id).ToList();
            return View();


        }
    }
}