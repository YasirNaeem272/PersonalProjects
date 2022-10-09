using BOL_Bussines_Object_Layer_;
using DAL_Data_Access_Layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Business_Logic_Layer_
{

    public class RoleBs
    {
        private RoleDb objDb;
        public RoleBs()
        {
            objDb = new RoleDb();
        }
        // RoleDb objDb = new RoleDb();
        public IEnumerable<tb_Role> GetAll()
        {
            return objDb.GetAll();
        }
        public tb_Role GetById(int id)
        {
            return objDb.GetById(id);
        }
        public void Insert(tb_Role role)
        {
             objDb.Insert(role);
        }
        public void Update(tb_Role role)
        {
            objDb.Update(role);
        }
        public void Delete(int id)
        {
            objDb.Delete(id);
        }
    }
}
