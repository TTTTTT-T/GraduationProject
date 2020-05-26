using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Model;
using BLL;

namespace UI
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //获取页面的值
            string userName = this.UserName.Text;
            string psw = this.Pwd.Text;
            //封装成实体对象
            UserInfo ui = new UserInfo();
            ui.UserName = userName;
            ui.Pwd = psw;


            UserInfoBLL uib = new UserInfoBLL();
            string result = uib.PlayUserInfo(ui);
            if (result=="0")
            {
                Response.Write("<script>alert('该用户已注册！')</script>");
            }
            else if (result == "1")
            {
                Response.Write("<script>alert('用户注册成功！')</script>");
            }
            else {
                Response.Write("<script>alert('用户注册失败！')</script>");
            }

        }
    }
}