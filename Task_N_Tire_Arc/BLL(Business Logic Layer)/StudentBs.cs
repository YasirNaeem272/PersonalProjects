using BOL_Bussines_Object_Layer_;
using DAL_Data_Access_Layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BLL_Business_Logic_Layer_
{
    public class StudentBs
    {
        StudentDb objDb = new StudentDb();
      
        public IEnumerable<tb_Student> GetAll()
        {
            return objDb.GetAll();
        }
        //public tb_Student GetById(int id)
        //{
        //    return objDb.GetById(id);
        //}
        public void Insert(tb_Student student)
        {
            objDb.Insert(student);
        }
        public void Update(tb_Student student)
        {
            objDb.Update(student);
        }
        public void Delete(int id)
        {
            objDb.Delete(id);
        }
        public void Save()
        {
            objDb.Save();
        }
        public tb_Student Details(int stid)
        {
              
            return objDb.Details(stid);
        }
        public List<tb_Class> GetClass()
        {
            return objDb.GetClass();
            //var StudentDb = new StudentDb();
            //List<tb_Class> Clname = StudentDb.GetClass();
            //return StudentDb.GetClass();
        }
        public List<tb_Address> GetAddress()
        {
            return objDb.GetAddress();
        }
        //
        public List<tb_Class> getclass(int id)
        {
            return objDb.getclass(id);
        }

        public List<tb_State> getstateclass(int id)
        {
           
            return objDb.getstateclass(id);
        }
        public List<tb_City> getcityclass(int id)
        {
            
            return objDb.getcityclass(id);
        }
        public List<tb_Area> getareaclass(int id)
        {
            
            return objDb.getareaclass(id);
        }
        //get dropdown data
        public tb_Student GetRecord(int id)
        {
            
            return objDb.GetRecord(id);
            
        }
        public List<tb_City> GetCity()
        {
            
            return objDb.GetCity();
        }
        public List<tb_State> GetState()
        {
            
            return objDb.GetState();
        }
        public List<tb_Area> GetArea()
        {
           
            return objDb.GetArea();
        }
        //this function call in ajax function

        public List<Citiea> GetStateId(int stateid)
        {

            return objDb.GetStateId(stateid);
        }
        public List<states> GetAreaId(int ctyId)
        {
            return objDb.GetAreaId(ctyId);
        }
        public List<getclass> GetClassId(string clname) //ajax
        {
              return objDb.GetClassId(clname);
        }
        //Get GetAreaCitySateId
        public GetAreaCitySateId GetNames(int Cityid, int Stateid, int Areaid) //Get City Id
        {

            return objDb.GetNames(Cityid, Stateid, Areaid);
        }
        public tb_Student GetPreviousRecord(int classid)
        {
           return  objDb.GetPreviousRecord(classid);
        }

    }
}
