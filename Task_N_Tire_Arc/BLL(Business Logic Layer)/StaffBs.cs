using BOL_Bussines_Object_Layer_;
using DAL_Data_Access_Layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Business_Logic_Layer_
{
    public class StaffBs
    {
        StaffDb objDb = new StaffDb();
        public IEnumerable<tb_Staff> GetAll() //SelectList
        {
            return objDb.GetAll();
        }
        public tb_Staff GetById(int id)
        {
            return objDb.GetById(id);
        }
        public void Insert(tb_Staff staff)
        {
            objDb.Insert(staff);
        }
        public void Update(tb_Staff staff)
        {
            objDb.Update(staff);
        }
        public void Delete(int id)
        {
            objDb.Delete(id);
        }
    }
}
