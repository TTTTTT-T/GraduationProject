using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class UserInfo
    {
        //用户ID
        public int UserID { get; set; }
        //用户姓名
        public string UserName { get; set; }
        //密码
        public string Pwd { get; set; }
        public string picture { get; set; }
        //是否删除
        public int IsDelete { get; set; }
    }
}
