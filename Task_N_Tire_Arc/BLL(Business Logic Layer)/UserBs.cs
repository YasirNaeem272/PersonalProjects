using BOL_Bussines_Object_Layer_;
using DAL_Data_Access_Layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Business_Logic_Layer_
{
    public class UserBs
    {
        UserDb objDb = new UserDb();
        RoleDb roleRepository = new RoleDb();
        public void Insert(tb_User user)
        {            
            var userRole = roleRepository.GetByName("user");
            user.Role_Id = userRole.Role_Id;
            objDb.Insert(user);
        }
        public tb_User Registration(tb_User user)
        {

            return  objDb.Registration(user);
        }
        public tb_User Login(tb_User user)
        {
            return objDb.Login(user);
        }
    }
}
