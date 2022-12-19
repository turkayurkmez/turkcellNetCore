using IntroducingNETCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntroducingNETCore.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            //return File();
            //return Json();
            ViewBag.Date = DateTime.Now;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                //db'ye kaydet...
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
