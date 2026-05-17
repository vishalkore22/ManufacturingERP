using Microsoft.AspNetCore.Mvc;

namespace ManufacturingERP.Areas.User.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
