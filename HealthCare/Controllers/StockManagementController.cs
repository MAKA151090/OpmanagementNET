using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    public class StockManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DrugInventory()
        {
            return View();
        }
        public IActionResult DrugCategoryMaster()
        {
            return View();
        }
        public IActionResult DrugStockMaster()
        {
            return View(); 
        }
        public IActionResult DrugTypeMaster()
        {
            return View();
        }
        public IActionResult DrugGroupMaster()
        {
            return View();
        }
        public IActionResult DrugRackMaster()
        {
            return View();
        }
    }
}
