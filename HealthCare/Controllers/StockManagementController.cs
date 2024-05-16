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

        public async Task<IActionResult> DrugStock(DrugStockModel model)
        {
            var existingStk = await GetDrugData.SHstkDrugStock.FindAsync(model.IDNumber, model.DrugID);
                if (existingStk != null)
            {
                existingStk.IDNumber = model.IDNumber;
                existingStk.DrugID = model.DrugID;
                existingStk.ManufacturingDate = model.ManufacturingDate;
                existingStk.ExpiryDate = model.ExpiryDate;
                existingStk.NumberOfStock  = model.NumberOfStock;
                existingStk.lastUpdatedDate = DateTime.Now.ToString();
                existingStk.lastUpdatedUser = "Myself";
                existingStk.lastUpdatedMachine = "Lap";

            }
                else
            {
                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = "Myself";
                model.lastUpdatedMachine = "Lap";
                GetDrugData.SHstkDrugStock.Add(model);

            }
            await GetDrugData.SaveChangesAsync();
            ViewBag.Message = "Saved Successfully.";
            return View("" , model);
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
