using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
namespace UI.back
{
    public partial class main1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void AddUserMessage(object sender, EventArgs e)
        {
            string username = this.username.Value;
            string pwd = this.password.Value;
            string filename = this.FileUpload1.FileName;
            int isDelete = int.Parse(this.isDelete.Value);

            if (!this.FileUpload1.HasFile)
            {
                return;
            }
            else
            {
                string flex = filename.Substring(filename.LastIndexOf(".") + 1).ToLower();

                if (flex != "jpg" && flex != "png")
                {
                    return;
                }
                else
                {

                    this.FileUpload1.SaveAs(Server.MapPath("~/picture/") + filename);
                }

            }

            UserInfo user = new UserInfo();
            user.UserName = username;
            user.Pwd = pwd;
            user.picture = filename;
            user.IsDelete = isDelete;

            UserInfoBLL bll = new UserInfoBLL();
            bool result = bll.AddUser(user);
            if (result)
            {
                Response.Write("<script>alert('添加成功')</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败')</script>");
            }
        }
    }
}