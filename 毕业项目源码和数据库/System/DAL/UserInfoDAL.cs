using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data;

namespace DAL
{
    public class UserInfoDAL
    {
        //添加用户
        public static bool AddUser(UserInfo user) {
            //定义SQL语句
            string sql = string.Format("insert into UserInfo  values('{0}','{1}','{2}',0) ",user.UserName,user.Pwd,user.picture);
            //调用DBHelper类执行添加，接收返回的bool值
            bool result =   DBHelper.Edit(sql);
            //返回结果给上一层BLL
          return result;
        }

        //通过用户名查询用户是否存在
        public static DataTable FindUserByUserName(string userName) {
            string sql = string.Format("select * from UserInfo where userName='{0}'", userName);
          DataTable  dt =  DBHelper.GetDataTable(sql);
          return dt;
        }
        //登录查询是否有数据
        public static DataTable FindUserCheck(UserInfo user) {
            string sql = string.Format("select * from UserInfo where userName='{0}' and pwd='{1}'", user.UserName, user.Pwd);
            DataTable dt = DBHelper.GetDataTable(sql);
            return dt;
        }

        //查询所有用户
        public static List<UserInfo> FindAll() {
            string sql = @"select * from UserInfo";
            DataTable dt = DBHelper.GetDataTable(sql);
            List<UserInfo> list = new List<UserInfo>();
            if(dt!=null||dt.Rows.Count>0){
                foreach (DataRow dr in dt.Rows)
                {
                    UserInfo info = new UserInfo();
                    info.UserID = int.Parse(dr["UserID"].ToString());
                    info.UserName = dr["UserName"].ToString();
                    info.Pwd = dr["Pwd"].ToString();
                    info.picture = dr["picture"].ToString();
                    info.IsDelete = int.Parse(dr["IsDelete"].ToString());
                    list.Add(info);
                    
                }
            }
            return list;
        }
    }
}
