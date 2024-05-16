using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            return View("DrugCategoryMaster", pCategory);


        }
        public async Task<IActionResult> DrugGroup (DrugGroupModel model) 
        {
            var existingGrp = await GetDrugData.SHstkDrugGroup.FindAsync(model.GroupTypeName,model.GroupTypeID);
            if (existingGrp != null)
            {
                existingGrp.GroupTypeID = model.GroupTypeID;
                existingGrp.GroupTypeName = model.GroupTypeName;
                existingGrp.lastUpdatedDate = DateTime.Now.ToString();
                existingGrp.lastUpdatedUser = "Myself";
                existingGrp.LastUpdatedmachine = "Lap";
            }
            else
            {
                model.lastUpdatedDate= DateTime.Now.ToString();
                model.lastUpdatedUser = "Myself";
                model.LastUpdatedmachine = "Lap";
                GetDrugData.SHstkDrugGroup.Add(model);
            }
            await GetDrugData.SaveChangesAsync();
            ViewBag.Message = "Saved Successfully.";
            return View("DrugGroupMaster", model);
        }

        public async Task<IActionResult> DrugType(DrugTypeModel pType)
        {

            var existingType = await GetDrugData.SHstkDrugType.FindAsync(pType.TypeID);
            if (existingType != null)
            {

                existingType.TypeID = pType.TypeID;
                existingType.TypeName = pType.TypeName;
                existingType.lastUpdatedDate = DateTime.Now.ToString();
                existingType.lastUpdatedUser = "Myself";
                existingType.lastUpdatedmachine = "Lap";
            }
            else
            {
                pType.lastUpdatedDate = DateTime.Now.ToString();
                pType.lastUpdatedUser = "Myself";
                pType.lastUpdatedmachine = "Lap";
                GetDrugData.SHstkDrugType.Add(pType);

            }
            await GetDrugData.SaveChangesAsync();
            ViewBag.Message = "Saved Successfully.";
            return View("DrugTypeMaster", pType);


        }

        public async Task<IActionResult> DrugRack(DrugRackModel pRack)
        {

            var existingRack = await GetDrugData.SHstkDrugRack.FindAsync(pRack.RackID, pRack.RackName);
            if (existingRack != null)
            {

                existingRack.RackID = pRack.RackID;
                existingRack.RackName = pRack.RackName;
                existingRack.UniqueIdentifier = pRack.UniqueIdentifier;
                existingRack.Comments = pRack.Comments;
                existingRack.lastUpdatedDate = DateTime.Now.ToString();
                existingRack.lastUpdatedUser = "Myself";
                existingRack.lastUpdatedmachine = "Lap";
            }
            else
            {
                pRack.lastUpdatedDate = DateTime.Now.ToString();
                pRack.lastUpdatedUser = "Myself";
                pRack.lastUpdatedmachine = "Lap";
                GetDrugData.SHstkDrugRack.Add(pRack);

            }
            await GetDrugData.SaveChangesAsync();
            ViewBag.Message = "Saved Successfully.";
            return View("DrugRackMaster", pRack);
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



     
        [HttpPost]
        public async Task<IActionResult> DrugInventory(DrugInventoryModel model)
        {

            var existingTest = await GetDrugData.SHstkDrugInventory.FindAsync(model.DrugId);
            if (existingTest != null)
            {

                existingTest.DrugId = model.DrugId;
                existingTest.ModelName = model.ModelName;
                existingTest.CategoryId = model.CategoryId;
                existingTest.TypeId = model.TypeId;
                existingTest.RockId = model.RockId;
                existingTest.MedicalDescription = model.MedicalDescription;
                existingTest.Price = model.Price;
                existingTest.SideEffects = model.SideEffects;
                existingTest.Therapy = model.Therapy;
                existingTest.User = model.User;
                existingTest.Company = model.Company;
                existingTest.BarCode = model.BarCode;
                existingTest.GroupName = model.GroupName;
                existingTest.GroupType = model.GroupType;
                existingTest.LastupdatedUser = "Myself";
                existingTest.LastupdatedDate = DateTime.Now.ToString(); ;
                existingTest.LastUpdatedMachine = "Myself";
                      }
            else
            {


                model.LastupdatedDate = DateTime.Now.ToString();
                model.LastupdatedUser = "Myself";
                model.LastUpdatedMachine = "Myself";
                GetDrugData.SHstkDrugInventory.Add(model);

            }
            await GetDrugData.SaveChangesAsync();
            ViewBag.Message = "Saved Successfully.";
            return View("DrugInventory", model);

        }
      


    }
}
