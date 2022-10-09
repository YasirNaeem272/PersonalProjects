using BLL_Business_Logic_Layer_;
using BOL_Bussines_Object_Layer_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI_User_Interface_.ViewModel;

namespace UI_User_Interface_.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        UserBs objUs = new UserBs();
        public ActionResult Login()
        {
            return View();
        }
        
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Login(tb_User user)
        {
            var chk = objUs.Login(user);
            string pass = string.Empty;
            if (chk != null)
            {
                pass = EncDec.Decrypt(chk.Usr_Password);
                if(pass.Equals (user.Usr_Password))
                {
                    return RedirectToAction("Create", "Student");
                }
                


            else
                {
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }
            [HttpPost]
        public ActionResult Registration(tb_User user)
        {
            var checking=objUs.Registration(user);
            if(checking != null)
            {
                ViewBag.Error = "This name is already exist";
                return RedirectToAction("Login", "User");
            }
            else
            {
                // user.Role_Id = 1;
                user.Usr_Password = ViewModel.EncDec.Encrypt(user.Usr_Password);
                objUs.Insert(user);
                return RedirectToAction("Login", "User");
            }
           // return View();
        }
    }
}