using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace YourNamespace.Controllers
{
    public class RandomPassController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            
            int? Count = HttpContext.Session.GetInt32("Count");
            if(Count == null)
            {
                Count = 0;
            }
            Count += 1;

            string PossibleCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string PassCode = "";
            Random Rand = new Random();
            for(int i = 0; i < 14; i++)
            {
                PassCode = PassCode + PossibleCharacters[Rand.Next(0, PossibleCharacters.Length)];
            }

            HttpContext.Session.SetInt32("Count", (int)Count);
            ViewBag.PassCode = PassCode;
            ViewBag.Count = Count;
            return View();
        }
    }
}