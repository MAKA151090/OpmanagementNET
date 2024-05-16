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
           
            var existingCat = await GetDrugData.SHstkMedCategory.FindAsync(pCategory.CategoryID);
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
                GetDrugData.SHstkMedCategory.Add(pCategory);

            }
            await GetDrugData.SaveChangesAsync();
            ViewBag.Message = "Saved Successfully.";
            return View("TestCreation", pCategory);


        }







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
