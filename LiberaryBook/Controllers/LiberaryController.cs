using Microsoft.AspNetCore.Mvc;

namespace LiberaryBook.Controllers
{
    public class LiberaryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
