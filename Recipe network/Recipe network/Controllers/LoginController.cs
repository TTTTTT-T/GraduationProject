using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Recipe_network.Models;
namespace Recipe_network.Controllers
{
    
    public class LoginController : Controller
    {
        ChowhoundNetEntities11 db = new ChowhoundNetEntities11();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Account, string Password)
        {   var DbUser = db.UserInfo.SingleOrDefault(x => x.Account == Account & x.pwd == Password);
            
            if (DbUser != null)
            {
                int UID = DbUser.userID;
                Session["id"] = UID;
                Session["UID"] = DbUser;
                
                 UserInfo user = (UserInfo)Session["UID"];
                if (user.userpic==null)
                {
                    user.userpic = "默认用户头像.png";
                }
               
               
                db.SaveChanges();
                return RedirectToAction("Index", "RecipeHome");
            }
            else
            {
                return Content("<script> alert('账号与密码不匹配'); history.go(-1);</script>");
            }
        }
        public ActionResult regist()
        {
            return View();

        }
     
        public ActionResult Insert(string Account, string pwd,string UName)
        {
            UserInfo use = new UserInfo();
            use.Account = Account;
            use.pwd = pwd;
            use.UName = UName;
            db.UserInfo.Add(use);
            db.SaveChanges();

           
               
                return Content("<script> alert('注册成功');history.go(-1);</script>");
            
          
        }
    }
}