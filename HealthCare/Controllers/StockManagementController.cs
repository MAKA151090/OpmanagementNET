using DocumentFormat.OpenXml.EMMA;
using HealthCare.Business;
using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

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


        public IActionResult Index()
        {
            return View();
        }



        public IActionResult DrugCategoryMaster()
        {
            DrugCategoryModel drugC = new DrugCategoryModel();

            return View("DrugCategoryMaster", drugC);
        }

        public async Task<IActionResult> DrugCategory(DrugCategoryModel pCategory,string buttonType)
        {
           if(buttonType == "Delete")
            {
                var DrugDelete = await GetDrugData.SHstkDrugCategory.FirstOrDefaultAsync(x => x.CategoryID == pCategory.CategoryID && x.IsDelete == false);
                if (DrugDelete != null)
                {
                    DrugDelete.IsDelete = true;

                    GetDrugData.SaveChanges();

                    ViewBag.message = "Deleted Successfully";
                    return View("DrugCategoryMaster", DrugDelete);
                }
                else
                {
                    DrugCategoryModel dlt = new DrugCategoryModel();
                    ViewBag.message = "CategoryID Not Found";
                    return View("DrugCategoryMaster", dlt);
                }
            }
            var existingCat = await GetDrugData.SHstkDrugCategory.FindAsync(pCategory.CategoryID);
            if (existingCat != null)
            {

                existingCat.CategoryID = pCategory.CategoryID;
                existingCat.CategoryName = pCategory.CategoryName;
                existingCat.IsDelete = pCategory.IsDelete;
                existingCat.lastUpdatedDate = DateTime.Now.ToString();
                existingCat.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingCat.lastUpdatedmachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                GetDrugData.Entry(existingCat).State = EntityState.Modified;
            }
            else
            {
                pCategory.lastUpdatedDate = DateTime.Now.ToString();
                pCategory.lastUpdatedUser = User.Claims.First().Value.ToString();
                pCategory.lastUpdatedmachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                GetDrugData.SHstkDrugCategory.Add(pCategory);

            }
            await GetDrugData.SaveChangesAsync();

            ViewBag.Message = "Saved Successfully";

            DrugCategoryModel drugC = new DrugCategoryModel();

            return View("DrugCategoryMaster", drugC);

        }


        [HttpGet]
        public async Task<IActionResult> GetDrugCat (DrugCategoryModel model)
        {
            var getdrugcat = await GetDrugData.SHstkDrugCategory.FirstOrDefaultAsync(x => x.CategoryID == model.CategoryID && x.IsDelete ==false);
            if(getdrugcat != null)
            {
                return View("DrugCategoryMaster", getdrugcat);
            }
            else
            {
                ViewBag.message="CategoryID Not Found";
            }

            DrugCategoryModel cat = new DrugCategoryModel();
            return View("DrugCategoryMaster", cat);

        }


        public IActionResult DrugGroupMaster()
        {
            DrugGroupModel DrugG = new DrugGroupModel();

            return View("DrugGroupMaster", DrugG);
        }

        public async Task<IActionResult> DrugGroup (DrugGroupModel model,string buttonType) 
        {
            
           
            if (string.IsNullOrEmpty(model.GroupTypeName))
            {
                ViewBag.Message = "Group Type Name is required";
                return View("DrugGroupMaster", model);
            }

            if(buttonType == "Delete")
            {
                var GroupDelete = await GetDrugData.SHstkDrugGroup.FirstOrDefaultAsync(x => x.GroupTypeID == model.GroupTypeID && x.IsDelete == false);
                if (GroupDelete != null)
                {
                    GroupDelete.IsDelete = true;

                    GetDrugData.SaveChanges();

                    ViewBag.message = "Deleted Successfully";
                    return View("DrugGroupMaster", GroupDelete);
                }
                else
                {
                    DrugGroupModel dlt = new DrugGroupModel();
                    ViewBag.message = "GroupID Not Found";
                    return View("DrugGroupMaster", dlt);
                }
            }

            var existingGrp = await GetDrugData.SHstkDrugGroup.FindAsync(model.GroupTypeName,model.GroupTypeID);
            if (existingGrp != null)
            {
                existingGrp.GroupTypeID = model.GroupTypeID;
                existingGrp.GroupTypeName = model.GroupTypeName;
                existingGrp.IsDelete = model.IsDelete;
                existingGrp.lastUpdatedDate = DateTime.Now.ToString();
                existingGrp.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingGrp.LastUpdatedmachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                GetDrugData.Entry(existingGrp).State = EntityState.Modified;

            }
            else
            {
                model.lastUpdatedDate= DateTime.Now.ToString();
                model.lastUpdatedUser = User.Claims.First().Value.ToString();
                model.LastUpdatedmachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                GetDrugData.SHstkDrugGroup.Add(model);
            }
            await GetDrugData.SaveChangesAsync();
            ViewBag.Message = "Saved Successfully";
            DrugGroupModel DrugG = new DrugGroupModel();

            return View("DrugGroupMaster", DrugG);
        }


        [HttpGet]
        public async Task<IActionResult> GetGroup (DrugGroupModel model)
        {
            var getgroup = await GetDrugData.SHstkDrugGroup.FirstOrDefaultAsync(x => x.GroupTypeID == model.GroupTypeID && x.IsDelete == false);
            if(getgroup != null)
            {
                return View("DrugGroupMaster", getgroup);
            }
            else
            {
                ViewBag.message = "GroupTypeID Not Found";
            }
            DrugGroupModel grp = new DrugGroupModel();
            return View("DrugGroupMaster",grp);
        }


        public IActionResult DrugTypeMaster()
        {

            DrugTypeModel DrugT = new DrugTypeModel();

            return View("DrugTypeMaster", DrugT);
        }

        public async Task<IActionResult> DrugType(DrugTypeModel pType,string buttonType)
        {
            if(buttonType == "Delete")
            {
                var TypeDelete = await GetDrugData.SHstkDrugType.FirstOrDefaultAsync(x => x.TypeID == pType.TypeID && x.IsDelete == false);
                if (TypeDelete != null)
                {
                    TypeDelete.IsDelete = true;

                    GetDrugData.SaveChanges();

                    ViewBag.message = "Deleted Successfully";
                    return View("DrugTypeMaster", TypeDelete);
                }
                else
                {
                    DrugTypeModel dlt = new DrugTypeModel();
                    ViewBag.message = "TypeID Not Found";
                    return View("DrugTypeMaster", dlt);
                }
            }
            var existingType = await GetDrugData.SHstkDrugType.FindAsync(pType.TypeID);
            if (existingType != null)
            {

                existingType.TypeID = pType.TypeID;
                existingType.TypeName = pType.TypeName;
                existingType.IsDelete = pType.IsDelete;
                existingType.lastUpdatedDate = DateTime.Now.ToString();
                existingType.lastUpdatedUser = User.Claims.First().Value.ToString();
                existingType.lastUpdatedmachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                GetDrugData.Entry(existingType).State = EntityState.Modified;
            }
            else
            {
                pType.lastUpdatedDate = DateTime.Now.ToString();
                pType.lastUpdatedUser = User.Claims.First().Value.ToString();
                pType.lastUpdatedmachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                GetDrugData.SHstkDrugType.Add(pType);

            }
            await GetDrugData.SaveChangesAsync();
            ViewBag.Message = "Saved Successfully";
            DrugTypeModel DrugT = new DrugTypeModel();

            return View("DrugTypeMaster", DrugT);


        }

        [HttpGet]
        public async Task<IActionResult> GetDrugtype(DrugTypeModel model)
        {
           
            var getDrug = await GetDrugData.SHstkDrugType.FirstOrDefaultAsync(x => x.TypeID == model.TypeID && x.IsDelete == false);
            if (getDrug != null)
            {
                return View("DrugTypeMaster", getDrug);
            }
            else
            {
                ViewBag.message = "TypeID Not Found";
            }
            DrugTypeModel typeid = new DrugTypeModel();
            return View("DrugTypeMaster", typeid);
        }



        public IActionResult DrugRackMaster()
        {
            return View();
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


        public IActionResult DrugStockMaster()
        {
            return View();
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

    
       public IActionResult DrugInventory()
        {

            BusinessClassStockManagement clinicAdmin = new BusinessClassStockManagement(GetDrugData);
            ViewData["Categoryid"] = clinicAdmin.GetCategoryid();
            ViewData["DrugTypeid"] = clinicAdmin.GetDrugTypeid();
            ViewData["DurgGroup"] = clinicAdmin.GetDurgGroup();
            ViewData["Getfac"] = clinicAdmin.GetFacility();

            DrugInventoryModel DrugI = new DrugInventoryModel();

            return View("DrugInventory", DrugI);
        }


        [HttpPost]
        public async Task<IActionResult> DrugInventory(DrugInventoryModel model,string buttonType)
        {
            BusinessClassStockManagement clinicAdm = new BusinessClassStockManagement(GetDrugData);
            ViewData["Categoryid"] = clinicAdm.GetCategoryid();
            ViewData["DrugTypeid"] = clinicAdm.GetDrugTypeid();
            ViewData["DurgGroup"] = clinicAdm.GetDurgGroup();
            ViewData["Getfac"] = clinicAdm.GetFacility();

            if (buttonType == "Delete")
            {

                var intvDelete = await GetDrugData.SHstkDrugInventory.FirstOrDefaultAsync(x => x.FacilityID == model.FacilityID && x.DrugId == model.DrugId && x.IsDelete == false);
                if (intvDelete != null)
                {
                    intvDelete.IsDelete = true;

                    GetDrugData.SaveChanges();

                    ViewBag.message = "Deleted Successfully";
                    return View("DrugInventory", intvDelete);
                }
                else
                {
                    DrugInventoryModel dlt = new DrugInventoryModel();
                    ViewBag.message = "DrugID Not Found";
                    return View("DrugInventory", dlt);
                }
            }

            var existingTest = await GetDrugData.SHstkDrugInventory.FindAsync(model.DrugId,model.FacilityID);
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
                existingTest.FacilityID = model.FacilityID;
                existingTest.IsDelete = model.IsDelete;
                existingTest.LastupdatedUser = User.Claims.First().Value.ToString();
                existingTest.LastupdatedDate = DateTime.Now.ToString(); ;
                existingTest.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                existingTest.Dosage = model.Dosage;

                GetDrugData.Entry(existingTest).State = EntityState.Modified;
            }
            else
            {


                model.LastupdatedDate = DateTime.Now.ToString();
                model.LastupdatedUser = User.Claims.First().Value.ToString();
                model.LastUpdatedMachine = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                GetDrugData.SHstkDrugInventory.Add(model);

            }
            await GetDrugData.SaveChangesAsync();
            ViewBag.Message = "Saved Successfully";

            BusinessClassStockManagement clinicAdmin = new BusinessClassStockManagement(GetDrugData);
            ViewData["Categoryid"] = clinicAdmin.GetCategoryid();
            ViewData["DrugTypeid"] = clinicAdmin.GetDrugTypeid();
            ViewData["DurgGroup"] = clinicAdmin.GetDurgGroup();
            ViewData["Getfac"] = clinicAdmin.GetFacility();

            DrugInventoryModel DrugI = new DrugInventoryModel();

            return View("DrugInventory", DrugI);

        }


        [HttpGet]
        public async Task<IActionResult>GetInvent (DrugInventoryModel model)
        {
            BusinessClassStockManagement clinicAdmin = new BusinessClassStockManagement(GetDrugData);
            ViewData["Categoryid"] = clinicAdmin.GetCategoryid();
            ViewData["DrugTypeid"] = clinicAdmin.GetDrugTypeid();
            ViewData["DurgGroup"] = clinicAdmin.GetDurgGroup();
            ViewData["Getfac"] = clinicAdmin.GetFacility();

            var getinvent = await GetDrugData.SHstkDrugInventory.FirstOrDefaultAsync(x => x.FacilityID == model.FacilityID && x.DrugId == model.DrugId && x.IsDelete==false);
            if (getinvent != null) 
            {
                return View("DrugInventory", getinvent);
            }
            else
            {
                ViewBag.message = "DrugID Not Found";
            }
            DrugInventoryModel innvent = new DrugInventoryModel();
            return View("DrugInventory", innvent);
        }
      


    }
}
