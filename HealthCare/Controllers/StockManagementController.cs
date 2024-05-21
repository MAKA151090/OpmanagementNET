using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HealthCare.Controllers
{
    [Authorize]
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
                existingCat.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingCat.lastUpdatedmachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            }
            else
            {
                pCategory.lastUpdatedDate = DateTime.Now.ToString();
                pCategory.lastUpdatedUser = User.Claims.First().Value.ToString();
                pCategory.lastUpdatedmachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
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
                existingGrp.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingGrp.LastUpdatedmachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            }
            else
            {
                model.lastUpdatedDate= DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                model.LastUpdatedmachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
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
                existingType.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingType.lastUpdatedmachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            }
            else
            {
                pType.lastUpdatedDate = DateTime.Now.ToString();
                pType.lastUpdatedUser = User.Claims.First().Value.ToString();
                pType.lastUpdatedmachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
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
                existingRack.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingRack.lastUpdatedmachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            }
            else
            {
                pRack.lastUpdatedDate = DateTime.Now.ToString();
                pRack.lastUpdatedUser = User.Claims.First().Value.ToString();
                pRack.lastUpdatedmachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
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
                existingStk.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingStk.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();


            }
                else
            {
                model.lastUpdatedDate = DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                model.lastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
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
                existingTest.LastupdatedUser = User.Claims.First().Value.ToString();
                existingTest.LastupdatedDate = DateTime.Now.ToString(); ;
                existingTest.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            }
            else
            {


                model.LastupdatedDate = DateTime.Now.ToString();
                model.LastupdatedUser = User.Claims.First().Value.ToString();
                model.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                GetDrugData.SHstkDrugInventory.Add(model);

            }
            await GetDrugData.SaveChangesAsync();
            ViewBag.Message = "Saved Successfully.";
            return View("DrugInventory", model);

        }
      


    }
}
