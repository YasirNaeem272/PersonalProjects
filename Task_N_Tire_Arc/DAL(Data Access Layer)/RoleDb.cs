using BOL_Bussines_Object_Layer_;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Data_Access_Layer_
{
    public class RoleDb
    {
        private TestEntities2 _db;

        public RoleDb()
        {
            _db = new TestEntities2();
        }
        public IEnumerable<tb_Role>GetAll() //Select List
        {
            return _db.tb_Role.ToList();
        }
        public tb_Role GetById(int id) //select single record
        {
           return _db.tb_Role.Find(id);
        }

        public tb_Role GetByName(string Rolename)  //Get Role name
        {
            return _db.tb_Role.FirstOrDefault(a => a.Role_Name == Rolename);
        }
        public void Insert(tb_Role role)
        {
            _db.tb_Role.Add(role);
            _db.SaveChanges();
        }
        public void Update(tb_Role role)
        {
            _db.Entry(role).State = EntityState.Modified;
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            tb_Role role = _db.tb_Role.Find(id);
            _db.tb_Role.Remove(role);
            _db.SaveChanges();
        }
    }
}
