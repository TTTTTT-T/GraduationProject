using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using System.Data;

namespace BLL
{
    public class UserInfoBLL
    {
        public string PlayUserInfo(UserInfo user)
        {
            DataTable dt = UserInfoDAL.FindUserByUserName(user.UserName);
            string flag;
            if (dt.Rows.Count > 0)
            {
                //提示用户已存在
                flag="0";
            }
            else
            {
                //调用新增
                bool result = UserInfoDAL.AddUser(user);
                if (result)
                {
                    //提示用户注册成功！
                    flag = "1";
                }
                else
                {
                    //用户注册失败！
                    flag="-1";
                }
            }

            return flag;
        }

       /// <summary>
       /// 查询所有用户
       /// </summary>
       /// <returns></returns>
        public List<UserInfo> FindALlUser() {
            return UserInfoDAL.FindAll();
        }

        public DataTable CheckUser(UserInfo user) {
            return UserInfoDAL.FindUserCheck(user);
        }
    }
}
