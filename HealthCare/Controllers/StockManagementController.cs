using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    public class StockManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MedicationInventory()
        {
            return View();
        }
        public IActionResult MedicationCategoryMaster()
        {
            return View();
        }
        public IActionResult MedicationStockMaster()
        {
            return View(); 
        }
        public IActionResult MedicationTypeMaster()
        {
            return View();
        }
        public IActionResult MedicationGroupMaster()
        {
            return View();
        }
        public IActionResult MedicationRackMaster()
        {
            return View();
        }
    }
}
