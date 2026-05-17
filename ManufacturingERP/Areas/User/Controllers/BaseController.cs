using Microsoft.AspNetCore.Mvc;

namespace ManufacturingERP.Areas.User.Controllers
{
    [Area("User")]
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
