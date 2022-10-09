using BLL_Business_Logic_Layer_;
using BOL_Bussines_Object_Layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI_User_Interface_.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        StaffBs objBs = new StaffBs();
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Create()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(tb_Staff staff)
        {
            objBs.Insert(staff);
            return View();
        }
    }
}