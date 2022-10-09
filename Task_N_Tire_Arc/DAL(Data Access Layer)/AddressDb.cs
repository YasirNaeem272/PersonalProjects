using BOL_Bussines_Object_Layer_;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Data_Access_Layer_
{
    public class AddressDb
    {
        TestEntities2 _db = new TestEntities2();

        public IEnumerable<tb_Address> GetAll()
        {
            return _db.tb_Address.ToList();
        }
        public tb_Address GetById(int id)
        {
            return _db.tb_Address.Find(id);
        }
        public int Insert(tb_Address address) //return address id
        {
            _db.tb_Address.Add(address);
           
            _db.SaveChanges();
            return address.Address_Id;
        }
        public int Update(tb_Address address)
        {
            _db.Entry(address).State = EntityState.Modified;
            _db.SaveChanges();
            return address.Address_Id;
        }
        public tb_Address GetAddressRecord(int id)
        {
            var model = _db.tb_Address.Find(id);
            return model;
        }
    }
}
