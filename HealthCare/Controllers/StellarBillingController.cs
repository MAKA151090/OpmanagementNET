using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    public class StellarBillingController : Controller
    {
       


        public IActionResult CategoryMasterModel()
        {
            return View();
        }

        public IActionResult ProductMasterModel()
        {
            return View();
        }

    }
}
