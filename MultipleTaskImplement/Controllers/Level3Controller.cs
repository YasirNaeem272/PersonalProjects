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
    public class Level3Controller : Controller
    {

        private readonly AddDbContext _Db;
        public Level3Controller(AddDbContext Db)
        {
            _Db = Db;
        }
        public IActionResult List()
        {

            try
            {
                var category = from a in _Db.task3


                               select new HeadLevel3 //ya hm nai lis bolie ha 
                               {
                                   Id = a.Id,
                                   Name = a.Name,
                                   Code = a.Code,

                               };

                List<HeadLevel3> headLevel3s = new List<HeadLevel3>();
                headLevel3s = _Db.task3.ToList();
                ViewBag.ProjectLists = headLevel3s;

                return View(category);

            }
            catch (Exception ex)
            {

                return View();
            }

        }

        public IActionResult Create(HeadLevel3 obj)  //ya first page ha jis mai hm create krhy hn
        {
            var list = (from a in _Db.task2
                        select new SelectListItem()
                        {

                            Value = a.Id.ToString(),
                            Text = a.Name.ToString()
                        }).ToList();
            list.Insert(0, new SelectListItem()
            {
                Value = string.Empty,
                Text = "---Select---"
            });
            ViewBag.Listoflist = list;
            return View();

        }

        public IActionResult GetBy(HeadLevel3 usr)
        {
            if (_Db.task3.Any(x => x.Name == usr.Name))
            {
                ModelState.AddModelError("duplicate", "this name already exists");
                return View("Create");
            }
            else if (_Db.task3.Any(x => x.Code == usr.Code))
            {
                ModelState.AddModelError("duplicate", "this name is already exist");
                return View("Create");
            }
            else  //ya hmra database mai save krha hy
            {
                _Db.task3.Add(usr);
                _Db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public async Task<IActionResult> DeleteStd(int id) // ya hmra data delete krha ha sara 
        {
            try
            {
                var std = await _Db.task3.FindAsync(id);
                if (std != null)
                {
                    _Db.task3.Remove(std);
                    await _Db.SaveChangesAsync();

                }
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {

                return RedirectToAction("List");
            }
        }
        public async Task<IActionResult> Edit(HeadLevel3 obj) //or ya function ya kam krha ha ya purana data lara ha obj k throughya dono function edit kry hn
        {
           
            
                return View(obj);
            

        }
        public async Task<IActionResult> Update(HeadLevel3 obj)
        {
            if(_Db.task.Any(x=>x.Code==obj.Code))
            {
                ViewBag.DuplicateMessage = "This Message is already exist:";
                return View("Edit");

            }
            else
            {
                _Db.Entry(obj).State = EntityState.Modified;
                await _Db.SaveChangesAsync();
                return RedirectToAction("List");
            }
          

        }
    }

}

