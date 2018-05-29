using Microsoft.AspNetCore.Mvc;
namespace LawInOrderApp.UI.Site.Controllers
{
    public class HomeController : Controller
    {
        [Route("welcome")]
        [Route("/")]
        public IActionResult Index()

        {
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Route("contact")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [Route("error")]
        public IActionResult Error()
        {
            return View();
        }

        [Route("access-denied")]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
