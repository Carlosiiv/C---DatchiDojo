using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DatchiDojo.Models;

using Microsoft.AspNetCore.Http; //<-- Isn't this session?

namespace DatchiDojo.Controllers
{
    public class GameController : Controller
    {

        Datchi d = new Datchi(); //pass in d as a session and then stamp it as a Datchi 

        [HttpGet("")]
        public IActionResult Game(Datchi d)
        {
            
            Datchi Retrieve = HttpContext.Session.GetObjectFromJson<Datchi>("DatchiD");
            if(Retrieve == null)
            {
                HttpContext.Session.SetObjectAsJson("DatchiD", d);
            }
            else
            {
                if(Retrieve.Happiness >= 100 && Retrieve.Fullness >= 100 && Retrieve.Energy >= 100)
                {
                    HttpContext.Session.SetObjectAsJson("DatchiD", Retrieve);
                    return RedirectToAction("Win");
                }
                if (Retrieve.Happiness <=0 || Retrieve.Fullness <=0 || Retrieve.Energy <=0)
                {
                    HttpContext.Session.SetObjectAsJson("DatchiD", Retrieve);
                    return RedirectToAction("Loss");
                }
            }
            return View(d);
        }

        [HttpGet("Reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Game");
        }

        [HttpGet("loss")]
        public IActionResult Loss()
        {
            Datchi Retrieve = HttpContext.Session.GetObjectFromJson<Datchi>("DatchiD");
            return View(Retrieve);
        }

        [HttpGet("win")]
        public IActionResult Win()
        {
            Datchi Retrieve = HttpContext.Session.GetObjectFromJson<Datchi>("DatchiD");
            return View(Retrieve);
        }

        [HttpGet("feed")]
        public IActionResult Feed()
        {
            Datchi Retrieve = HttpContext.Session.GetObjectFromJson<Datchi>("DatchiD");
            // d = Retrieve;
            Retrieve.Feed();
            Retrieve.Image = "https://pic.funnygifsbox.com/uploads/2019/07/funnygifsbox.com-2019-07-07-11-09-34-34.gif";
            HttpContext.Session.SetObjectAsJson("DatchiD", Retrieve);
            return RedirectToAction("Game",Retrieve);
        }

        [HttpGet("work")]
        public IActionResult Work()
        {
            Datchi Retrieve = HttpContext.Session.GetObjectFromJson<Datchi>("DatchiD");
            Retrieve.Work();
            HttpContext.Session.SetObjectAsJson("DatchiD", Retrieve);
            return RedirectToAction("Game",Retrieve);
        }

        [HttpGet("play")]
        public IActionResult Play()
        {
            Datchi Retrieve = HttpContext.Session.GetObjectFromJson<Datchi>("DatchiD");
            Retrieve.Play();
            HttpContext.Session.SetObjectAsJson("DatchiD", Retrieve);
            return RedirectToAction("Game", Retrieve);
        }

        [HttpGet("sleep")]
        public IActionResult Sleep()
        {
            Datchi Retrieve = HttpContext.Session.GetObjectFromJson<Datchi>("DatchiD");
            Retrieve.Sleep();
            HttpContext.Session.SetObjectAsJson("DatchiD", Retrieve);
            return RedirectToAction("Game",Retrieve);
        }
    }
}