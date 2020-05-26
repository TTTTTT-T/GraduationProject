using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

namespace UI.MessageSystem
{
    public partial class FindUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack){
            UserInfoBLL bll = new UserInfoBLL();
            this.Repeater1.DataSource = bll.FindALlUser();
            this.Repeater1.DataBind();
             }
        }
        protected void updateValue(object sender, EventArgs e)
        {
            Response.Write("<script>alert('1！');</script>");
        }
    }
}