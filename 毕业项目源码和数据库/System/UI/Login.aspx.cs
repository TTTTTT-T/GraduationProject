using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Timers;
using System.Data;
using Model;
using BLL;

namespace UI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
            
                HttpCookie cook = Request.Cookies["pic"];
                if (cook!=null) {
                    this.headPic.Src = cook.Value.ToString();
                }
            }

        }
        protected void LoginCheck(object sender, EventArgs e)
        {

            var userName = this.UserName.Value;
            var pwd = this.Pwd.Value;
            if (userName != "" && pwd != "")
            {
                UserInfo info = new UserInfo();
                info.UserName = userName;
                info.Pwd = pwd;
                UserInfoBLL bll = new UserInfoBLL();
                DataTable dt = bll.CheckUser(info);
                if (dt.Rows.Count>0)
                {
                    string pic = dt.Rows[0]["picture"].ToString();
                    Session["picture"] = "~/picture/" + pic;
                    Session["UserName"] = userName;
                    this.headPic.Src = "~/picture/" + pic;
                    HttpCookie cookie = new HttpCookie("pic", "~/picture/" + pic);
                    cookie.Expires = DateTime.Now.AddDays(3);
                    Response.Cookies.Add(cookie);
                    Response.Redirect("MessageSystem/FindUser.aspx");
                    
                    //Session["UserName"] = userName;

                }
                else
                {
                    Response.Write("<script>alert('账号密码不正确或用户不存在！');</script>");
                }
            }
        }
        
    }
}