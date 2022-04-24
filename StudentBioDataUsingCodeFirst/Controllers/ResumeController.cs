using Microsoft.AspNetCore.Mvc;
using Secondtask.Data;
using Secondtask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Secondtask.Controllers
{
   
    public class ResumeController : Controller
    {
        private readonly ResumeDbContext _context;
        public ResumeController(ResumeDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Applicant> applicants;
            applicants = _context.Applicants.ToList();
            return View(applicants);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Applicant applicant = new Applicant();
            applicant.Experiences.Add(new Experience() { ExperienceId = 1 });
           // applicant.Experiences.Add(new Experience() { ExperienceId = 2 });
            //applicant.Experiences.Add(new Experience() { ExperienceId = 3 });

            return View(applicant);
        }

        [HttpPost]
        public IActionResult Create(Applicant applicant)
        {
            foreach(Experience experience in applicant.Experiences)
            {
                if (experience.CompanyName == null || experience.CompanyName.Length == 0)
                    applicant.Experiences.Remove(experience);
            }
            _context.Add(applicant);
            _context.SaveChanges();
            return RedirectToAction("index");

        }
    }
}
