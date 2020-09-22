using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Recipe_network.Models;
using System.IO;
using System.Data;

namespace Recipe_network.Controllers
{

    public class SubmitRecipeController : Controller
    {
        ChowhoundNetEntities11 db = new ChowhoundNetEntities11();
       
        // GET: SubmitRecipe
        public ActionResult Index()
        {
            if (Session["id"]==null)
            {
                return RedirectToAction("Index", "Login");
            }
            Session["photo"] = "";
            Session["BuImageimge"] = "";
            Session["photo1"] = "";
            ViewBag.types = db.Typetypes.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Add(Typetypes typetype,BuImage buImage, Menuinformation menuinformation, string RName, IEnumerable<HttpPostedFileBase> BuImageimge)
        {
            
             foreach (var file in BuImageimge)
            {
                if (file.ContentLength+1 > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/images"), fileName);
                    Session["BuImageimge"] += fileName + ",";
                    file.SaveAs(path);
                }
            }
            
            menuinformation.MenuinformationImg = Session["photo"].ToString();
            buImage.BuImageimge = Session["BuImageimge"].ToString();
            UserInfo user = (UserInfo)Session["UID"];
            menuinformation.userID = user.userID;
            menuinformation.Ingredients = Session["rname"].ToString();
            menuinformation.directions = Session["rname2"].ToString();
            db.Menuinformation.Add(menuinformation);
            db.SaveChanges();


            Menuinformation me = db.Menuinformation.OrderByDescending(p => p.MenuinformationID).FirstOrDefault();
            if (me!=null)
            {              
                buImage.MenuinformationID = me.MenuinformationID;
                buImage.discriptss = Session["rname2"].ToString();
                db.BuImage.Add(buImage);               
                db.SaveChanges();
            }
            else
            {
                return Content("<script>alert('食谱提交失败');history.go(-1)</script>");
            }

            string[] name = Session["photo"].ToString().Split(',');
            string a = name[0];
            return Content("<script>alert('食谱提交成功');history.go(-1)</script>");

        }
        public ActionResult Add1( string RName,string RName2)
        {
            Session["rname"] = RName;
            Session["rname2"] = RName2;
            return Content("");
        }
        [HttpPost]
        public ActionResult Upload()
        {

           
                //从Request中取参数，注意上传的文件在Requst.Files中
                string name = Request["name"];
                Session["photo"] += name + ",";

                int total = Convert.ToInt32(Request["total"]);
                int index = Convert.ToInt32(Request["index"]);
                var data = Request.Files["data"];

                //保存一个分片到磁盘上
                string dir = Server.MapPath("~/images");
                string file = Path.Combine(dir, name + "_" + index);
                data.SaveAs(file);
                string[] files = Directory.GetFiles(dir, name + "*");
                //如果已经是最后一个分片，组合
                //当然你也可以用其它方法比如接收每个分片时直接写到最终文件的相应位置上，但要控制好并发防止文件锁冲突
                if (files.Length == total)
                {
                    file = Path.Combine(dir, name);
                    var fs = new FileStream(file, FileMode.Create);
                    for (int i = 1; i <= total; ++i)
                    {
                        string part = Path.Combine(dir, name + "_" + i);
                        var bytes = System.IO.File.ReadAllBytes(part);
                        fs.Write(bytes, 0, bytes.Length);
                        bytes = null;
                        System.IO.File.Delete(part);
                    }
                    fs.Close();
                }

                //返回是否成功，此处做了简化处理
                return Json(new { Error = 0 });

            }






    }
}