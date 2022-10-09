using BOL_Bussines_Object_Layer_;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Data_Access_Layer_
{
   public class StaffDb
    {
        TestEntities2 _db = new TestEntities2();
        public IEnumerable<tb_Staff> GetAll() //SelectList
        {
            return _db.tb_Staff.ToList();
        }
        public tb_Staff GetById(int id)
        {
            return _db.tb_Staff.Find(id);
        }
        public void Insert(tb_Staff staff)
        {
            _db.tb_Staff.Add(staff);
            _db.SaveChanges();
        }
        public void Update(tb_Staff staff)
        {
            _db.Entry(staff).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            tb_Staff staff = _db.tb_Staff.Find(id);
            _db.tb_Staff.Remove(staff);
            _db.SaveChanges();
        }
    }
}
