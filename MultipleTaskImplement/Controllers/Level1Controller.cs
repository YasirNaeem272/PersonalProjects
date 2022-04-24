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
    public class Level1Controller : Controller
    {

        private readonly AddDbContext _Db;
        public Level1Controller(AddDbContext Db)
        {
            _Db = Db;
        }
        public IActionResult List()
        {

            try
            {
                var category = from a in _Db.task


                               select new HeadLevel //ya hm nai lis bolie ha 
                               {
                                   Id = a.Id,
                                   Name = a.Name,
                                   Code = a.Code,

                               };

                List<HeadLevel> headLevels = new List<HeadLevel>();
                headLevels = _Db.task.ToList();
                ViewBag.ProjectLists = headLevels;

                return View(category);

            }
            catch (Exception ex)
            {

                return View();
            }

        }

        public IActionResult Create(HeadLevel obj)  //ya first page ha jis mai hm create krhy hn
        {
            return View();

        }

        public IActionResult GetBy(HeadLevel usr)  // ya hmra create page ko save krha ha or ya check bhi krha ha k same tou ni ha
        {
            if (_Db.task.Any(x => x.Name == usr.Name))
            {
                ModelState.AddModelError("duplicate", "this name already exists");
                return View("Create");
            }
            else if (_Db.task.Any(x => x.Code == usr.Code))
            {
                ModelState.AddModelError("duplicate", "this name is already exist");
                return View("Create");
            }
            else  //ya hmra database mai save krha hy
            {
                _Db.task.Add(usr);
                _Db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public async Task<IActionResult> DeleteStd(int id) // ya hmra data delete krha ha sara 
        {
            try
            {
                var std = await _Db.task.FindAsync(id);
                if (std != null)
                {
                    _Db.task.Remove(std);
                    await _Db.SaveChangesAsync();

                }
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {

                return RedirectToAction("List");
            }
        }
        public async Task<IActionResult> Edit(HeadLevel obj) //or ya function ya kam krha ha ya purana data lara ha obj k throughya dono function edit kry hn
        {
            return View(obj);

            //if (_Db.task.Any(x => x.Name == obj.Name))
            //{
            //    ModelState.AddModelError("duplicate", "this name already exists");
            //    ViewBag.DuplicateMessage = "this name is already exist:";
            //    return View();
            //}
            //else if (_Db.task.Any(x => x.Code == obj.Code))
            //{
            //    ModelState.AddModelError("duplicate", "this Code Already exist");
            //    ViewBag.DuplicateMessage = "this code already exists";
            //    return View();
            //}
            //else
            //{
            //    return View(obj);
            //}

        }
        public async Task<IActionResult> Update(HeadLevel obj)
        {
          
            if (_Db.task.Any(x => x.Code == obj.Code))
            {
         
                ViewBag.DuplicateMessage = "this code already exists";
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



    

