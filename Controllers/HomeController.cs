using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using dachi.Models;

namespace dojodachi.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet("")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("getDachi") != null)
            {
                string oldDachi = HttpContext.Session.GetString("getDachi");
                Dachi dachi = JsonConvert.DeserializeObject<Dachi>(oldDachi);
                ViewBag.currentDachi = dachi;
            }
            else
            {
                Dachi dachi = new Dachi();
                ViewBag.currentDachi = dachi;
                string newDachi = JsonConvert.SerializeObject(dachi);
                HttpContext.Session.SetString("getDachi", newDachi);
            }
            return View();
        }
        [HttpPost("update")]
        public IActionResult Update(string action)
        {
            string oldDachi = HttpContext.Session.GetString("getDachi");
            Dachi dachi = JsonConvert.DeserializeObject<Dachi>(oldDachi);
            Random rand = new Random();
            switch (action)
            {
                case "Feed":
                    dachi.Feed();
                    break;
                case "Play":
                    dachi.Play();
                    break;
                case "Work":
                    dachi.Work();
                    break;
                case "Sleep":
                    dachi.Sleep();
                    break;
            }
            if (dachi.Fullness < 1 || dachi.Happiness < 1)
            {
                dachi.Messages = "Your DojoDachi has died :(";
                string newDachi = JsonConvert.SerializeObject(dachi);
                HttpContext.Session.SetString("getDachi", newDachi);
            }
            else if(dachi.Energy > 99 && dachi.Fullness > 99 && dachi.Happiness > 99)
            {
                dachi.Messages = "Congrats! You've won! You have done a good job raising your DojoDachi!";
                string newDachi = JsonConvert.SerializeObject(dachi);
                HttpContext.Session.SetString("getDachi", newDachi);
            }
            else
            {
                string newDachi = JsonConvert.SerializeObject(dachi);
                HttpContext.Session.SetString("getDachi", newDachi);
            }
            return RedirectToAction("Index");
        }
        [HttpPost("new")]
        public IActionResult New()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("index");
        }
    }
}