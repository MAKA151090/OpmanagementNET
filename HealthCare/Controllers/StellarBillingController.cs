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

        public IActionResult CustomerBilling()
        {
            return View();
        }

        public IActionResult CustomerMaster()
        {
            return View();
        }

        public IActionResult DiscountCategoryMaster()
        {
            return View();
        }

        public IActionResult GSTMasterModel()
        {
            return View();
        }

       public IActionResult VoucherCustomerDetails()
        {
            return View();
        }
    }
}
