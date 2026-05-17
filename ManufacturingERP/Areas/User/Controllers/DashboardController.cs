using Microsoft.AspNetCore.Mvc;

namespace ManufacturingERP.Areas.User.Controllers
{
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
