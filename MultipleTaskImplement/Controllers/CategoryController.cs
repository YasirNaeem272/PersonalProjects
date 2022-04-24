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
    public class CategoryController : Controller
    {
        private readonly AddDbContext _Db;
        public CategoryController(AddDbContext Db)
        {
            _Db = Db;
        }
        public IActionResult Category()
        {
            return View();
        }
        public IActionResult Save(Category1 obj)
        {
            _Db.category.Add(obj);
            _Db.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult List()
        {
            try
            {
                var cat = from a in _Db.category
                          select new Category1
                          {
                              Id = a.Id,
                              Name = a.Name,
                              Code = a.Code
                          };
                List<Category1> category1s = new List<Category1>();
                category1s = _Db.category.ToList();
                ViewBag.ProjectLists = category1s;
                return View(cat);
            }
            catch (Exception ex)
            {

                return View();
            }


           
        }
        public IActionResult Edit(Category1 obj)
        {
            return View("Edit");
        }
        [HttpPost]
        public IActionResult Update(Category1 obj)
        {
            _Db.Entry(obj).State = EntityState.Modified;
            _Db.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var a = _Db.category.Find(id);
                if(a!=null)
                {
                    _Db.category.Remove(a);
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

