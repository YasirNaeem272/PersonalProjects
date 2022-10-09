using BOL_Bussines_Object_Layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL_Business_Logic_Layer_;

namespace UI_User_Interface_.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        private RoleBs objRl;
        public RoleController()
        {
            objRl = new RoleBs();
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Create()
        {

            
            return View();
        }
        [AcceptVerbs( HttpVerbs.Post)]
        public ActionResult Create(tb_Role role)
        {

            objRl.Insert(role);
            return View();
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit()
        {
          
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(tb_Role role)
        {
            objRl.Update(role);
            return View();
        }
        public ActionResult Delete(int id)
        {
            return View();
        }
    }
}