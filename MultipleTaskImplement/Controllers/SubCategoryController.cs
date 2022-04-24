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
    public class SubCategoryController : Controller
    {
      
            private readonly AddDbContext _Db;
            public SubCategoryController(AddDbContext Db)
            {
                _Db = Db;
            }
            public IActionResult SubCategory()
            {

            var list = (from a in _Db.category
                        select new SelectListItem()
                        {

                            Value = a.Id.ToString(),
                            Text = a.Name.ToString()
                        }).ToList();
            list.Insert(0, new SelectListItem()
            {
                Value = string.Empty,
                Text = "---Select SubCategory---"
            });
            ViewBag.Listoflist = list;
           
            return View();
            }

            public IActionResult Save(Subcategory obj)
            {
                _Db.subcategory.Add(obj);
                _Db.SaveChanges();
                return RedirectToAction("List");
        }

            public IActionResult List()
            {
                try
                {
                    var cat = from a in _Db.subcategory
                              select new Subcategory
                              {
                                  Id = a.Id,
                                  Name = a.Name,
                                  Code = a.Code
                              };
                    List<Subcategory> subcategories = new List<Subcategory>();
                    subcategories = _Db.subcategory.ToList();
                    ViewBag.ProjectLists = subcategories;
                    return View(cat);
                }
                catch (Exception ex)
                {

                    return View();
                }



            }
            public IActionResult Edit(Subcategory obj)
            {
                return View("Edit");
            }
            [HttpPost]
            public IActionResult Update(Subcategory obj)
            {
                _Db.Entry(obj).State = EntityState.Modified;
                _Db.SaveChanges();
                return RedirectToAction("List");
            }

            public IActionResult Delete(int id)
            {
                try
                {
                    var a = _Db.subcategory.Find(id);
                    if (a != null)
                    {
                        _Db.subcategory.Remove(a);
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


