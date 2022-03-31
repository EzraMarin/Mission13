using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        public IBowlersRepository bowlrepo { get; set; }
        
        
        //constructor
        public HomeController(IBowlersRepository b)
        {
            bowlrepo = b;
         
        }

        public IActionResult Index()
        {
            var blah = bowlrepo.Bowlers
                .ToList();

            return View(blah);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var bowler = bowlrepo.Bowlers.Single(x => x.BowlerID == id);

            return View("BowlerInfo", bowler);
        }

        [HttpPost]
        public IActionResult Edit(Bowler b)
        {
            if (ModelState.IsValid)
            {
                bowlrepo.UpdateBowler(b);

                return RedirectToAction("Index");
            }
            else
            {
                return View("BowlerInfo", b);
            }
        }

        [HttpGet]
        public IActionResult Add()
        {

            return View("BowlerInfo");
        }

        [HttpPost]
        public IActionResult Add(Bowler blah)
        {
            bowlrepo.AddBowler(blah);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bowler = bowlrepo.Bowlers.Single(x => x.BowlerID == id);
           
            return View("Index");
        }

        [HttpPost]
        public IActionResult Delete(Bowler blah)
        {
            bowlrepo.RemoveBowler(blah);

            return View("Index");
        }
    }
}
