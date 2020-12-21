using Microsoft.AspNetCore.Mvc;

namespace Organizer.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

    }
}