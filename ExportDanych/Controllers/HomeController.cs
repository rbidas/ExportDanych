using System.Web.Mvc;

namespace ExportDanych.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Backup", new { });
        }
    }
}
