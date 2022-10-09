using BOL_Bussines_Object_Layer_;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Data_Access_Layer_
{
   public class SubjectDb
    {
        TestEntities2 _db = new TestEntities2();
        public IEnumerable<tb_Subject> GetAll() // Select list
        {
            return _db.tb_Subject.ToList();
        }

        public void Insert(tb_Subject subject)
        {
            _db.tb_Subject.Add(subject);
            _db.SaveChanges();
        }
        public void Update(tb_Subject subject)
        {
            _db.Entry(subject).State = EntityState.Modified;
            _db.SaveChanges();
        }
        ////////
        public  tb_Subject GetRecord(int id)
        {
            var model = _db.tb_Subject.Find(id);
            return model;
        }
        //get dropdown
        public List<tb_Staff> Getstaff()
        {
            var a = (from x in _db.tb_Staff select x).ToList();
            return a;
        }
        public List<tb_Class> Getclass()
        {
            var a = (from x in _db.tb_Class select x).ToList();
            return a;
        }
        public List<tb_Staff> getstaffname(int id)
        {
            var stfname = GetRecord(id).tb_Staff.Stf_Name;
            var res = Getstaff().Where(x => x.Stf_Name == stfname).ToList();
            List<tb_Staff> _st = new List<tb_Staff>();
            foreach (var item in res)
            {
                if(item.Stf_Name== stfname)
                {
                    tb_Staff staff = new tb_Staff
                    { 
                     Stf_Id=item.Stf_Id,
                     Stf_Name=item.Stf_Name,
                     Isselect= 1
                    };
                    _st.Add(staff);
                }
                else
                {
                    tb_Staff staff = new tb_Staff
                    {
                        Stf_Id = item.Stf_Id,
                        Stf_Name = item.Stf_Name,
                        Isselect = 0
                    };
                    _st.Add(staff);
                }
            }
            var sts = _st;
            return sts;

        }
        public List<tb_Class> getclassname(int id)
        {
            //var clname = GetRecord(id).tb_Class.Class_Name;
            //var clsid = GetRecord(id).tb_Class.Class_Name;
            //var clses = Getclass();
            //var allcl = Getclass().Where(x=>x.Class_Name== clses).ToList();
            var allcl = Getclass().ToList()/*.Where(x=>x.Class_Name==clname).ToList()*/;
            //List<tb_Class> _Classes = new List<tb_Class>();
            //foreach (var item in allcl)
            //{
            //    tb_Class cl = new tb_Class
            //    {
            //        Class_Id = item.Class_Id,
            //        Class_Name = item.Class_Name,
            //        Isselect = item.Class_Name == clname ? 1 : 0
            //    };
                
            //    _Classes.Add(cl);
              
            //}
            //var res = _Classes;
            return allcl;
        }
    }
}
