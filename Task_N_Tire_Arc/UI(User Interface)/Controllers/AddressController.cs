using BLL_Business_Logic_Layer_;
using BOL_Bussines_Object_Layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI_User_Interface_.Controllers
{
    public class AddressController : Controller
    {
        // GET: Address
        AddressBs objBs = new AddressBs();
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Create()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(tb_Address address)
        {
            objBs.Insert(address);
            return View();
        }
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Edit(int id)
        {
            var model = objBs.GetAddressRecord(id);
            return  View(model);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(tb_Address address)
        {
            objBs.Update(address);
            return View();
        }
        public ActionResult List()
        {
            var model = objBs.GetAll();
            return View(model);
        }
    }
}