using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task.Models;

namespace task.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentContext _Db;
        public StudentController(StudentContext Db)
        {
            _Db = Db;
        }
        public IActionResult StudentList()
        {

            try
            {
                // ya hmnay join lgie ha between two tables or ya database lie ga data
                var stdlist = from a in _Db.tb_student
                              join b in _Db.tb_Departments
                              on a.DepId equals b.Id into Dep
                              from b in Dep.DefaultIfEmpty()

                              select new Student
                              {
                                  Id = a.Id,
                                  Name=a.Name,
                                  FName=a.FName,
                                  DepId=a.DepId,
                                  Department=b==null?"":b.Department
                                  
                                  


                              };
                return View(stdlist);
            }
            catch (Exception ex)
            {

                return View();
            }
           
        }
        public IActionResult Create(Student obj)
        {
            loadDDl();
            return View(obj);
           
           
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent (Student obj)
        {
            try
            {
                if(ModelState.IsValid)// ya id ki validation karaha ha j id zero k braber ha ya ni 
                {
                    if(obj.Id==0)
                    {
                        _Db.tb_student.Add(obj);
                        await _Db.SaveChangesAsync();
                    }
                    else
                    {
                        _Db.Entry(obj).State = EntityState.Modified;
                        await _Db.SaveChangesAsync();
                    }
                    return RedirectToAction("StudentList");
                }
                return View();
            }
            catch (Exception ex)
            {

                return RedirectToAction("StudentList");
            }
        }

        public async Task<IActionResult> DeleteStd(int id) // ya hmra data delete krha ha sara 
        {
            try
            {
                var std = await _Db.tb_student.FindAsync(id);
                if(std!=null)
                {
                    _Db.tb_student.Remove(std);
                    await _Db.SaveChangesAsync();

                }
                return RedirectToAction("StudentList");
            }
            catch (Exception ex)
            {

                return RedirectToAction("StudentList");
            }
        }
        public void loadDDl()  //ya second table load hoo k ai ga hmara
        {
            try
            {
                List<Departments> depList = new List<Departments>(); // department ka constructor ha
                depList = _Db.tb_Departments.ToList();
                depList.Insert(0, new Departments {Id=0, Department= "Please select" });
                ViewBag.DepList = depList;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
