using BOL_Bussines_Object_Layer_;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DAL_Data_Access_Layer_
{
    public class StudentDb
    {

        TestEntities2 _db = new TestEntities2();
        public IEnumerable<tb_Student> GetAll() //Select List
        {
            return _db.tb_Student.ToList();
        }
        //public tb_Student GetById(int id) //select single record
        //{
        //    return _db.tb_Student.Find(id);
        //}
        public void Insert(tb_Student student)
        {

            _db.tb_Student.Add(student);
              _db.SaveChanges();
           // Save();
        }
        public void Update(tb_Student student)
        {
            _db.Entry(student).State = EntityState.Modified;
             _db.SaveChanges();
            //Save();
        }
        public void Delete(int id)
        {
            tb_Student role = _db.tb_Student.Find(id);
            _db.tb_Student.Remove(role);
              _db.SaveChanges();
            //Save();
        }
        public void Save()
        {
            _db.SaveChanges();
            
        }
        public tb_Student Details( int stid)
        {
            var data = _db.tb_Student.Where(x => x.Std_Id == stid).FirstOrDefault();
            return data;
        }
        public List<tb_Class> GetClass() //GetAll Data

        {

            var cl = (from x in _db.tb_Class select x).ToList();
            //var cl = _db.tb_Class.Select(s => s.Class_Name).Distinct().OrderBy(Class_Name=> Class_Name).ToList();
            return cl;

        }
        public List<tb_Address> GetAddress()
        {

            var ad = (from x in _db.tb_Address select x).ToList();
            return (ad);
        }

        public tb_Student GetRecord(int id) // Edit record get
        {

            // var model = _db.tb_Student.AsNoTracking().Where(x=>x.Std_Id==id).FirstOrDefault();
            var model = _db.tb_Student.Find(id);
            return model;
        }
        //get all record in each table
        public List<tb_Class> getclass(int id)
        {
            var reas = _db.tb_Class.ToList();

            var classname = GetRecord(id).tb_Class.Class_Name;
            var secname = GetRecord(id).tb_Class.Class_Section;
            var _clSections = GetClass().Where(x => x.Class_Name == classname).ToList();
            List<tb_Class> _Classes = new List<tb_Class>();
            foreach (var item in _clSections)
            {
                if (item.Class_Section == secname)
                {
                    tb_Class clas = new tb_Class
                    {
                        Class_Id = item.Class_Id,
                        Class_Name = item.Class_Name,
                        Class_Section = item.Class_Section,
                        Isselect = 1,
                    };
                    _Classes.Add(clas);
                }
                else
                {
                    tb_Class clas = new tb_Class
                    {
                        Class_Id = item.Class_Id,
                        Class_Name = item.Class_Name,
                        Class_Section = item.Class_Section,
                        Isselect = 0
                    };
                    _Classes.Add(clas);
                }
            }
            var clsys = _Classes;
            return clsys;
        }
        public List<tb_State> getstateclass(int id)
        {
            var reas = _db.tb_State.ToList();
            var statename = GetRecord(id).tb_Address.Address_State;
            List<tb_State> _States = new List<tb_State>();
            foreach (var item in reas)
            {
                if (item.State_Name == statename)
                {
                    tb_State state = new tb_State
                    {
                        State_Id = item.State_Id,
                        State_Name = item.State_Name,
                        Isselect = 1
                    };
                    _States.Add(state);
                }
                else
                {
                    tb_State state = new tb_State
                    {
                        State_Id = item.State_Id,
                        State_Name = item.State_Name,
                        Isselect = 0
                    };
                    _States.Add(state);
                }
            }
            var states = _States;
            return states;
        }
        public List<tb_City> getcityclass(int id)
        {
            var StateName = GetRecord(id).tb_Address.Address_State;
            var SelectCity = GetRecord(id).tb_Address.Address_City;
            //var stateId = GetState().Where(x => x.State_Id ==SelectCity)
            var reas = GetCity().Where(x => x.tb_State.State_Name == StateName).ToList();
            List<tb_City> _Cities = new List<tb_City>();
            //var reas = _db.tb_City.ToList();
            foreach (var item in reas)
            {
                if (item.City_Name == SelectCity)
                {
                    tb_City _City = new tb_City()
                    {
                        City_Id = item.City_Id,
                        City_Name = item.City_Name,
                        Isselect = 1
                    };
                    _Cities.Add(_City);
                }
                else
                {
                    tb_City _City = new tb_City()
                    {
                        City_Id = item.City_Id,
                        City_Name = item.City_Name,
                        Isselect = 0
                    };
                    _Cities.Add(_City);
                }
            }
            var cityies = _Cities;
            return cityies;
        }
        public List<tb_Area> getareaclass(int id)
        {
            var Areaname = GetRecord(id).tb_Address.Address_Area;
            var ctyname = GetRecord(id).tb_Address.Address_City;
            var ctID = GetCity().Where(x => x.City_Name == ctyname).FirstOrDefault().City_Id;

            List<tb_Area> area = new List<tb_Area>();
            var reas = GetArea().Where(x => x.City_Id == ctID);
            //var reas = _db.tb_Area.ToList();
            foreach (var item in reas)
            {

                if (item.Area_Name == Areaname)
                {
                    tb_Area _Area = new tb_Area
                    {
                        Area_Id = item.Area_Id,
                        Area_Name = item.Area_Name,
                        Isselect = 1,
                    };
                    area.Add(_Area);
                }
                else
                {
                    tb_Area _Area = new tb_Area
                    {
                        Area_Id = item.Area_Id,
                        Area_Name = item.Area_Name,
                        Isselect = 0,
                    };
                    area.Add(_Area);
                }

            }
            var setareas = area;
            return setareas;
        }
        //get dropdown data
        public List<tb_City> GetCity()
        {
            var res = (from x in _db.tb_City select x).ToList();

            return res;
        }
        public List<tb_State> GetState()
        {
            var res = (from x in _db.tb_State select x).ToList();
            return res;
        }
        public List<tb_Area> GetArea()
        {
            var res = (from x in _db.tb_Area select x).ToList();
            return res;
        }


        public GetAreaCitySateId GetNames(int Cityid, int Stateid, int Areaid) //Get City Id
        {
            GetAreaCitySateId a = new GetAreaCitySateId();
            //var cityI = Convert.ToInt32(Cityid);
            //var tb_s = _db.tb_City.ToList().Where(x => x.City_Id == cityI).FirstOrDefault();
            a.res1 = _db.tb_City.Find(Cityid).City_Name;
            a.res3 = _db.tb_Area.Find(Areaid).Area_Name;
            a.res2 = _db.tb_State.Find(Stateid).State_Name;

            return a;
        }
      


        // this function call in ajax function
        public List<Citiea> GetStateId(int stateid)
        {
            var stId = _db.tb_City.Where(x => x.State_Id == stateid).Select(s => new Citiea() { res2 = s.City_Name, res3 = s.City_Id }).ToList();
            return stId;
        }
        public List<states> GetAreaId(int ctyId)
        {
            var id = _db.tb_Area.Where(x => x.City_Id == ctyId).Select(s => new states() { res1 = s.Area_Name, res2 = s.Area_Id }).ToList();
            return id;
        }
        public List<getclass> GetClassId(string clname)
        {
            var id = _db.tb_Class.Where(x => x.Class_Name==clname).Select(s => new getclass() { res1 = s.Class_Section, res2 = s.Class_Id }).ToList();
            return id;
        }
        public tb_Student GetPreviousRecord(int classid)
        {
            tb_Student student = _db.tb_Student.Where(x => x.Class_Id == classid).FirstOrDefault();
            return student;
        }
    }
}
public class GetAreaCitySateId
{
    public string res1;
    public string res2;
    public string res3;
}

public class Citiea
{
    public int res3;
    public string res2;
}
public class states
{
    
    public string res1;
    public int res2;
}

public class getclass
{

    public string res1;
    public int res2;
}

