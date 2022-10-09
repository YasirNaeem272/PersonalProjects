using BLL_Business_Logic_Layer_;
using BOL_Bussines_Object_Layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI_User_Interface_.Controllers
{
    public class SubjectController : Controller
    {
        // GET: Subject
        SubjectBs objBs = new SubjectBs();
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.classes = objBs.Getclass().Select(s=> s.Class_Name ).Distinct();
            ViewBag.staff = objBs.Getstaff();
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(tb_Subject subject)
        {
            objBs.Insert(subject);
            return View();
        }
        [HttpPost]
        public ActionResult Edit(tb_Subject subject)
        {
            ViewBag.staffselected = objBs.Getstaff();
            ViewBag.classselected = objBs.Getclass();
            objBs.Update(subject);
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.staffselected = objBs.getstaffname(id);
            //ViewBag.selected = objBs.Getclass().Select(s=>s.Class_Name).Distinct();
            //ViewBag.selected = read;
            ViewBag.classselected = objBs.Getclass();
            var model = objBs.GetRecord(id);
            return View(model);
        }
        public ActionResult List()
        {
            var lis = objBs.GetAll();
            return View(lis);
        }
    }
}