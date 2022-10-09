using BOL_Bussines_Object_Layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Data_Access_Layer_
{
   public class UserDb
    {
        TestEntities2 _db = new TestEntities2();
        public void Insert(tb_User user)
        {
            _db.tb_User.Add(user);
            _db.SaveChanges();
        }
        public tb_User Registration(tb_User user)
        {
            //var check = (from c in _db.tb_User where c.Usr_Email == user.Usr_Email  select c).FirstOrDefault();
            var check = _db.tb_User.Where(x => x.Usr_Email == user.Usr_Email).FirstOrDefault();

            return check;
        }
        public tb_User Login(tb_User user)
        {
            var check = _db.tb_User.Where(x => x.Usr_Email == user.Usr_Email).FirstOrDefault();
             return check;
        }
    }
}
