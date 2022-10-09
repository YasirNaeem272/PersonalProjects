using BOL_Bussines_Object_Layer_;
using DAL_Data_Access_Layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Business_Logic_Layer_
{
    public class AddressBs
    {
        AddressDb objDb = new AddressDb();
        public IEnumerable<tb_Address> GetAll()
        {
            return objDb.GetAll();
        }
        public tb_Address GetById(int id)
        {
            return objDb.GetById(id);
        }
        public int Insert(tb_Address address)
        {
          return  objDb.Insert(address);
        }
        public int Update(tb_Address address)
        {
           return objDb.Update(address);
        }
        public tb_Address GetAddressRecord(int id)
        {
            return objDb.GetAddressRecord(id);
            
        }
    }
}
