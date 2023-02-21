using DateMe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DateMe.Controllers
{
    public class HomeController : Controller
    {
        private DateInfoContext daContext { get; set; }
        //Constructor
        public HomeController( DateInfoContext someName)
        {
            daContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DatingApplication()
        {
            ViewBag.Majors = daContext.Majors.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult DatingApplication(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                daContext.Add(ar);
                daContext.SaveChanges();
                return View("Confirmation", ar);

            }
            else
            {
                return View(ar);
            }

        }
        public IActionResult Waitlist ()
        {
            var applications = daContext.responses
                .Include(x => x.Major)
                .Where(x => x.CreeperStalker == false)
                .OrderBy(x => x.LastName)
                .ToList();

            return View(applications);
        }
        [HttpGet]
        public IActionResult Edit ( int applicationid)
        {
            ViewBag.Majors = daContext.Majors.ToList();

            var application = daContext.responses.Single(x => x.ApplicationID == applicationid);

            return View("DatingApplication", application);
        }
        [HttpPost]
        public IActionResult Edit (ApplicationResponse blah)
        {
            //daContext.Update(blah);
            //daContext.SaveChanges();
            //return RedirectToAction("Waitlist");
            if (ModelState.IsValid)
            {
                daContext.Add(blah);
                daContext.SaveChanges();
                return View("Confirmation", blah);
            }
            else
            {
                return View();
            }
        }
        public IActionResult Delete()
        {
            return View();
        }
    }
}
