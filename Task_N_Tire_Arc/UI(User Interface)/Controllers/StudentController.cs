using BLL_Business_Logic_Layer_;
using BOL_Bussines_Object_Layer_;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI_User_Interface_.Models;


namespace UI_User_Interface_.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        StudentBs objSl = new StudentBs();
        AddressBs objadd = new AddressBs();

        GetAreaCitySateId obj = new GetAreaCitySateId();
        //TestEntities _db = new TestEntities();
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Create()
        {
            var read = objSl.GetClass().Select(s => s.Class_Name).Distinct();
            ViewBag.Class = read;
            ViewBag.Address = objSl.GetAddress();
            ViewBag.City = objSl.GetCity();
            ViewBag.State = objSl.GetState();
            ViewBag.Area = objSl.GetArea();

            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Entity_Student entity_Student)
        {
            //  if (ModelState.IsValid)
            // {
            ViewBag.Class = objSl.GetClass();
            ViewBag.Address = objSl.GetAddress();
            ViewBag.City = objSl.GetCity();
            ViewBag.State = objSl.GetState();
            ViewBag.Area = objSl.GetArea();

            string fileName = Path.GetFileNameWithoutExtension(entity_Student.UserImageFile.FileName);
            string extension = Path.GetExtension(entity_Student.UserImageFile.FileName);

            fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;

            entity_Student.Std_Image = "~/Images/" + fileName;

            fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
            entity_Student.UserImageFile.SaveAs(fileName);
            var addRs = objSl.GetNames(Convert.ToInt32(entity_Student.City_Name), Convert.ToInt32(entity_Student.Area_Name), Convert.ToInt32(entity_Student.State_Name));

            tb_Address address = new tb_Address

            {

                Address_City = addRs.res1,
                Address_Area = addRs.res3,
                Address_State = addRs.res2,
                // Address_Complete_Adres=entity_Student.Address_Complete_Adres,


            };
            // objSl.addresssave(address);
            var addID = objadd.Insert(address);
            tb_Student obj = new tb_Student
            {
                //Std_Id = entity_Student.Std_Id,
                Std_F_Name = entity_Student.F_Name,
                Std_L_Name = entity_Student.L_Name,
                Std_Cntct_Number = entity_Student.Cntct_Number,
                Std_Image = entity_Student.Std_Image,
                Class_Id = entity_Student.Class_Id,
                Address_Id = addID,
            };

            objSl.Insert(obj);

            return RedirectToAction("List");
            // }
            // return View();
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(int id)
        {
            // objSl.GetRecord(id);
            var read = objSl.GetClass().Select(s => s.Class_Name).Distinct();
            ViewBag.Class = read;

            ViewBag.Address = objSl.GetAddress();
            var cty = objSl.GetCity();
            ViewBag.City = cty;

            var state = objSl.GetState()/*.Select(s=>s.State_Name).Distinct()*/;
            ViewBag.State = state;

            var ar = objSl.GetArea();
            ViewBag.Area = ar;
            // Isselected values
            ViewBag.selectedcity = objSl.getcityclass(id);

            ViewBag.selectedstate = objSl.getstateclass(id);
            ViewBag.selectedarea = objSl.getareaclass(id);
            ViewBag.selectedclass = objSl.getclass(id);

            
            var model = objSl.GetRecord(id);
          
            Session["Image"] = model.Std_Image;

            //var adId = model.Address_Id;
            //TempData["addid"] = adId;
            TempData["id"] = model.Std_Image;

            Entity_Student obj1 = new Entity_Student
            {
                Std_Id = model.Std_Id,
                F_Name = model.Std_F_Name,
                L_Name = model.Std_L_Name,
                Cntct_Number = model.Std_Cntct_Number,
                Std_Image = model.Std_Image,
                Class_Id = model.tb_Class.Class_Id,
                Address_Id = model.Address_Id,
                Class_Name = model.tb_Class.Class_Name,
                Class_Section = model.tb_Class.Class_Section,
                Area_Name = model.tb_Address.Address_Area,
                State_Name = model.tb_Address.Address_State,
                City_Name = model.tb_Address.Address_City,
                

            };


            return View(obj1);

        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(HttpPostedFileBase UserImageFile,Entity_Student student)
        {
           
            //string fileName = Path.GetFileNameWithoutExtension(student.UserImageFile.FileName);
            //string extension = Path.GetExtension(student.UserImageFile.FileName);

            //fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;

            //student.Std_Image = "~/Images/" + fileName;

            //fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
            //student.UserImageFile.SaveAs(fileName);
            if (UserImageFile != null)
            {

                //string filename = Path.GetFileName(UserImageFile.FileName);
                //string _filename = DateTime.Now.ToString("yymmssfff") + filename;
                //string extension = Path.GetExtension(UserImageFile.FileName);
                //string path = Path.Combine(Server.MapPath("~/Images/"), _filename);
                //student.Std_Image = "~/Images/" + _filename;
                string fileName = Path.GetFileNameWithoutExtension(student.UserImageFile.FileName);
                string extension = Path.GetExtension(student.UserImageFile.FileName);

                fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;

                student.Std_Image = "~/Images/" + fileName;

                fileName = Path.Combine(Server.MapPath("~/Images/"), fileName);
                student.UserImageFile.SaveAs(fileName);
                string oldImagePath = Request.MapPath(Session["Image"].ToString());
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }

            }
            else
            {
                student.Std_Image = Session["Image"].ToString();
                // var img = objSl.GetRecord(student.Std_Id).Std_Image;
                var img = (Convert.ToString(TempData["id"]));
                if (img == student.Std_Image)
                {
                  
                    TempData["msg"] = "Data Updated";
                }
            }
         
            // Class Name And section Name Not Select this Condition Execute
            var clname = objSl.GetClass().Where(x => x.Class_Id == student.Class_Id).FirstOrDefault().Class_Id;

            //TempData["cityId"] = clname;
            //var cityId = Convert.ToInt32(TempData["cityId"]);
            // var secname = objSl.getclass().Where(x => x.Class_Section == student.Class_Section).Select(s=> new {s.Class_Id });

            //var olddata = objSl.Details(student.Std_Id);
            var getrec = objSl.GetPreviousRecord(student.Class_Id);
            //var cityid = objSl.GetCity().Where(x => x.City_Id == student.City_Id).FirstOrDefault().City_Id;
            //var areaid = objSl.GetArea().Where(x => x.Area_Id == student.Area_Id).FirstOrDefault().Area_Id;
            //var stateid = objSl.GetState().Where(x => x.State_Id == student.State_Id).FirstOrDefault().State_Id;

            var addRs = objSl.GetNames(student.City_Id, student.State_Id, student.Area_Id);
                

                tb_Address address = new tb_Address

                {
                  
                    Address_City = addRs.res1,
                    Address_Area = addRs.res3,
                    Address_State = addRs.res2,
                    Address_Id = student.Address_Id,


                };
                var addID = objadd.Update(address);

                tb_Student obj = new tb_Student
                {
                    Std_Id = student.Std_Id,
                    Std_F_Name = student.F_Name,
                    Std_L_Name = student.L_Name,
                    Std_Cntct_Number = student.Cntct_Number,
                    Std_Image = student.Std_Image,
                    Class_Id = Convert.ToInt32(student.Class_Section),
                    Address_Id = addID,
                };
                objSl.Update(obj);
            //}

            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            var lst = objSl.GetAll();
            return View(lst);
        }
        [HttpPost]
        public ActionResult GetSection(string ClassName)
        {
            //var editId = Convert.ToInt32(TempData["id"]);
            //var SecID = objSl.getclass().Where(x => x.Class_Name == ClassName).Select(s => new { s.Class_Section, s.Class_Id, s.Isselect }).ToList();
          //  var name = objSl.GetRecord(editId).tb_Class.Class_Section;
            var SecID = objSl.GetClassId(ClassName);
            return Json(SecID, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GetStateRecord(int StateID)
        {   
           // var editId = Convert.ToInt32(TempData["id"]); // get edit id
           //var name = objSl.GetRecord(StateID).tb_Address.Address_State;
            // var st = objSl.getcityclass(editId).Where(x => x.State_Id == StateID).Select(a => new { a.City_Name, a.City_Id ,a.Isselect }).ToList();
             //objSl.getcityclass(StateID);
            var st = objSl.GetStateId(StateID); //get cities name
            return Json(st, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetAreaRecord(int AreaId)
        {
            //var editId = Convert.ToInt32(TempData["id"]);
            //var arid = objSl.getareaclass().Where(x => x.City_Id == AreaId).Select(a => new { a.Area_Id, a.Area_Name }).ToList();
            //var areaname = objSl.GetRecord(editId).tb_Address.Address_Area;
            // var arid = objSl.getareaclass(editId)/*.Where(x=>x.Area_Id==AreaId).Select(s=>new {s.Area_Name }).ToList()*/;
            var arid = objSl.GetAreaId(AreaId); // get areas name
            return Json(arid, JsonRequestBehavior.AllowGet);
        }
        //public ActionResult Saveaddress(tb_Student student)
        //{
        //    objSl.addresssave(student);
        //    return;
        //}
    }
}