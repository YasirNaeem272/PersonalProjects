using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TashBlock.Context;
using TashBlock.Models;

namespace TashBlock.Controllers
{
    public class SupplierController : Controller
    {
      
        private readonly AddDbContext _Db;
        public SupplierController(AddDbContext Db)
        {
            _Db = Db;
        }


        public IActionResult Supplier(Supplier obj)
        {
            
            return View();

        }
        public IActionResult Save(Supplier obj)
        {
            _Db.supplier.Add(obj);
            _Db.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            try
            {
                var cat = from a in _Db.supplier
                          select new Supplier //yahan model ka name ata ha
                          {
                              Id=a.Id,
                              SupplierName=a.SupplierName,
                              SupplierEmail=a.SupplierEmail,
                              CountryCode=a.CountryCode,
                              SupplierPhoneNumber=a.SupplierPhoneNumber,
                              SupplierAddress=a.SupplierAddress,
                              LocationName=a.LocationName,
                              SupplierCompanyName=a.SupplierCompanyName
                              
                          };
                List<Supplier> suppliers= new List<Supplier>();
                suppliers = _Db.supplier.ToList();
                ViewBag.ProjectLists = suppliers;
                return View(cat);
            }
            catch (Exception ex)
            {

                return View();
            }



        }
        public IActionResult Edit(Supplier obj)
        {
            return View("Edit");
        }

        public IActionResult Update(Supplier obj)
        {
            _Db.Entry(obj).State = EntityState.Modified;
            _Db.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var a = _Db.supplier.Find(id);
                if (a != null)
                {
                    _Db.supplier.Remove(a);
                    _Db.SaveChanges();
                }
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {

                return RedirectToAction("List");
            }

        }
    }
}
