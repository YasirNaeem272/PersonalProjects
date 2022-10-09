using BOL_Bussines_Object_Layer_;
using DAL_Data_Access_Layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Business_Logic_Layer_
{
    public class SubjectBs
    {
        SubjectDb objDb = new SubjectDb();
        public IEnumerable<tb_Subject> GetAll() // Select list
        {
           return objDb.GetAll();
        }

        public void Insert(tb_Subject subject)
        {
            objDb.Insert(subject);
        }
        public void Update(tb_Subject subject)
        {
            objDb.Update(subject);
        }
        ////////
        public tb_Subject GetRecord(int id)
        {
            
            return objDb.GetRecord(id);
        }
        // get dropdown
        public List<tb_Staff> Getstaff()
        {
            
            return objDb.Getstaff();
        }
        public List<tb_Class> Getclass()
        {
            
            return objDb.Getclass();
        }
        public List<tb_Staff> getstaffname(int id)
        {
            return objDb.getstaffname(id);
        }
        public List<tb_Class> getclassname(int id)
        {
            return objDb.getclassname(id);
        }
    }
}
