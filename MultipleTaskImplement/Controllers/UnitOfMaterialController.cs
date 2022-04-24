using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TashBlock.Context;
using TashBlock.Models;

namespace TashBlock.Controllers
{
    public class UnitOfMaterialController : Controller
    {
        private readonly AddDbContext _Db;
        public UnitOfMaterialController(AddDbContext Db)
        {
            _Db = Db;
        }
        public IActionResult Material(Unitofmaterial obj)
        {
            return View();
        }
        public IActionResult Save(Unitofmaterial obj)
        {
            _Db.Unitofmaterial.Add(obj);
            _Db.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            try
            {
                var cat = from a in _Db.Unitofmaterial
                          select new Unitofmaterial
                          {
                              Id = a.Id,
                              Name = a.Name,
                              Code = a.Code
                          };
                List<Unitofmaterial> unitofmaterials = new List<Unitofmaterial>();
                unitofmaterials = _Db.Unitofmaterial.ToList();
                ViewBag.ProjectLists = unitofmaterials;
                return View(cat);
            }
            catch (Exception ex)
            {

                return View();
            }



        }
        public IActionResult Edit(Unitofmaterial obj)
        {
            return View("Edit");
        }
        [HttpPost]
        public IActionResult Update(Unitofmaterial obj)
        {
            _Db.Entry(obj).State = EntityState.Modified;
            _Db.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var a = _Db.Unitofmaterial.Find(id);
                if (a != null)
                {
                    _Db.Unitofmaterial.Remove(a);
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
