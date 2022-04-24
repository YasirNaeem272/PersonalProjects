using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TashBlock.Context;
using TashBlock.Models;

namespace TashBlock.Controllers
{
    public class PurchaseOrderController : Controller
    {
        private readonly AddDbContext _Db;
        public PurchaseOrderController(AddDbContext Db)
        {
            _Db = Db;
        }
        public IActionResult purchaseorder(purchaseorder obj)
        {
            var list = (from a in _Db.supplier
                        select new SelectListItem()
                        {

                            Value = a.Id.ToString(),
                            Text = a.SupplierName.ToString()
                        }).ToList();
            list.Insert(0, new SelectListItem()
            {
                Value = string.Empty,
                Text = "---Select SupplierName---"
            });
            ViewBag.Listoflist = list;
            return View();

        }
        public IActionResult Save(purchaseorder obj)
        {
            _Db.purchaseorder.Add(obj);
            _Db.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            try
            {
                var cat = from a in _Db.purchaseorder
                          select new purchaseorder //yahan model ka name ata ha
                          {
                              Id = a.Id,
                             PurchaseOrderDate=a.PurchaseOrderDate,
                             PurchaseOrderNo=a.PurchaseOrderNo,
                             Terms=a.Terms,
                             Ref_MroNo=a.Ref_MroNo,
                             Attn=a.Attn,
                             FaxNo=a.FaxNo,
                             ContactPerson=a.ContactPerson,
                             ProjectTitle=a.ProjectTitle,
                             DeliverTo=a.DeliverTo,
                             SupplierName=a.SupplierName,
                             SupplierLocation=a.SupplierLocation,
                             //ProductName=a.ProductName,
                             //ProductCode=a.ProductCode,
                             //Price=a.Price,
                             //Quality=a.Quality,
                             //Discount=a.Discount,
                             //Value=a.Value,
                             //Total=a.Total,
                             //TotalQuality=a.TotalQuality,
                             //NetAmount=a.NetAmount,
                             //DiscountOptional=a.DiscountOptional,
                             //ValueOptional=a.ValueOptional,
                             //SalesTax=a.SalesTax
                              
                          };
                List<purchaseorder> purchaseorders = new List<purchaseorder>();
                purchaseorders = _Db.purchaseorder.ToList();
                ViewBag.ProjectLists = purchaseorders;
                return View(cat);
            }
            catch (Exception ex)
            {

                return View();
            }



        }
        [HttpGet]
        public IActionResult Create() // ya hm nai modal create kia ha
        {
            purchaseorder purchaseorder = new purchaseorder();
            return View("PartialView",purchaseorder);

        }
        [HttpPost]
        public IActionResult Create(purchaseorder purchaseorder)  // ya modal(means popup) is ka data save kry ga 
        {
            _Db.purchaseorder.Add(purchaseorder);
            _Db.SaveChanges();
            return View("PartialView", purchaseorder);

        }
        public IActionResult Edit(purchaseorder obj)
        {
            return View("Edit");
        }

        public IActionResult Update(purchaseorder obj)
        {
            _Db.Entry(obj).State = EntityState.Modified;
            _Db.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var a = _Db.purchaseorder.Find(id);
                if (a != null)
                {
                    _Db.purchaseorder.Remove(a);
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
