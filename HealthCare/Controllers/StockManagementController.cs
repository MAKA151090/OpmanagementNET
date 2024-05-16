using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Controllers
{
    public class StockManagementController : Controller
    {
        private HealthcareContext GetDrugData;

        public StockManagementController(HealthcareContext GetDrugData)
        {
            this.GetDrugData = GetDrugData;
        }

        public async Task<IActionResult> DrugCategory(DrugCategoryModel pCategory)
        {
           
            var existingCat = await GetDrugData.SHstkDrugCategory.FindAsync(pCategory.CategoryID);
            if (existingCat != null)
            {

                existingCat.CategoryID = pCategory.CategoryID;
                existingCat.CategoryName = pCategory.CategoryName;
                existingCat.lastUpdatedDate = DateTime.Now.ToString();
                existingCat.lastUpdatedUser = "Myself";
                existingCat.lastUpdatedmachine = "Lap";
            }
            else
            {
                pCategory.lastUpdatedDate = DateTime.Now.ToString();
                pCategory.lastUpdatedUser = "Myself";
                pCategory.lastUpdatedmachine = "Lap";
                GetDrugData.SHstkDrugCategory.Add(pCategory);

            }
            await GetDrugData.SaveChangesAsync();
            ViewBag.Message = "Saved Successfully.";
            return View("TestCreation", pCategory);


        }







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
