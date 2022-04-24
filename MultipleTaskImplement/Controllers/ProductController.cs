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
    public class ProductController : Controller
    {
        private readonly AddDbContext _Db;
        public  ProductController(AddDbContext Db)
        {
            _Db = Db;
        }

       
        public IActionResult Product(Product obj)
    {
           
                var list = (from a in _Db.category  // ya category ki list ai gi
                            select new SelectListItem()
                            {

                                Value = a.Id.ToString(),
                                Text = a.Name.ToString()
                            }).ToList();
                list.Insert(0, new SelectListItem()
                {
                    Value = string.Empty,
                    Text = "---SelectCategory---"
                });
                ViewBag.Listoflist = list;
               

            var list1 = (from a in _Db.subcategory  // ya Subcategory ki list ai gi
                        select new SelectListItem()
                        {

                            Value = a.Id.ToString(),
                            Text = a.Name.ToString()
                        }).ToList();
            list1.Insert(0, new SelectListItem()
            {
                Value = string.Empty,
                Text = "---SelectSubCategory---"
            });
            ViewBag.Listoflist1 = list1;

            var list2 = (from a in _Db.Unitofmaterial  // ya Unitofmaterial ki list ai gi
                         select new SelectListItem()
                         {

                             Value = a.Id.ToString(),
                             Text = a.Name.ToString()
                         }).ToList();
            list2.Insert(0, new SelectListItem()
            {
                Value = string.Empty,
                Text = "---SelectUOM---"
            });
            ViewBag.Listoflist2 = list2;
            var list3 = (from a in _Db.task3  // ya Level3 ki list ai gi
                         select new SelectListItem()
                         {

                             Value = a.Id.ToString(),
                             Text = a.Name.ToString()
                         }).ToList();
            list3.Insert(0, new SelectListItem()
            {
                Value = string.Empty,
                Text = "---SelectLevel3---"
            });
            ViewBag.Listoflist3 = list3;
            return View();

        }
    public IActionResult Save(Product obj)
    {
        _Db.product.Add(obj);
        _Db.SaveChanges();
        return RedirectToAction("List");
    }

    public IActionResult List()
    {
        try
        {
            var cat = from a in _Db.product
                      select new Product //yahan model ka name ata ha
                      {
                          Id = a.Id,
                          CategoryId = a.CategoryId,
                          SubCategoryId = a.SubCategoryId,
                          ProductName=a.ProductName,
                          ProductCode=a.ProductCode,
                          CostPrice=a.CostPrice,
                          SellingPrice=a.SellingPrice,
                          UnitofMaterial=a.UnitofMaterial,
                          Level3Id=a.Level3Id
                      };
            List<Product> products = new List<Product>();
                products = _Db.product.ToList();
            ViewBag.ProjectLists = products;
            return View(cat);
        }
        catch (Exception ex)
        {

            return View();
        }



    }
    public IActionResult Edit(Product obj)
    {
        return View("Edit");
    }

    public IActionResult Update(Product obj)
    {
        _Db.Entry(obj).State = EntityState.Modified;
        _Db.SaveChanges();
        return RedirectToAction("List");
    }

    public IActionResult Delete(int id)
    {
        try
        {
            var a = _Db.product.Find(id);
            if (a != null)
            {
                _Db.product.Remove(a);
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
