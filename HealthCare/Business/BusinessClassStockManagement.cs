using HealthCare.Context;
using HealthCare.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.Business
{
    public class BusinessClassStockManagement : Controller
    {
        private readonly HealthcareContext _healthcareContext;

        public BusinessClassStockManagement(HealthcareContext healthcareContext)
        {
            _healthcareContext = healthcareContext;
        }

        ///Dropdown for DrugInventory
        public List<DrugCategoryModel> GetCategoryid(string facility)
        {
            var Categoryid = (
                    from pr in _healthcareContext.SHstkDrugCategory
                    where pr.FacilityID == facility && pr.IsDelete == false
                    select new DrugCategoryModel
                    {
                        CategoryID = pr.CategoryID,
                        CategoryName = pr.CategoryName
                    }

                ).ToList();
            return Categoryid;
        }


        public List<DrugTypeModel> GetDrugTypeid(string facility)
        {
            var DrugTypeid = (
                    from pr in _healthcareContext.SHstkDrugType
                    where pr.FacilityID == facility && pr.IsDelete == false
                    select new DrugTypeModel
                    {
                        TypeID = pr.TypeID,
                        TypeName = pr.TypeName
                    }
                ).ToList();
            return DrugTypeid;
        }

        public List<DrugGroupModel> GetDurgGroup(string facility)
        {
            var DurgGroup = (
                    from pr in _healthcareContext.SHstkDrugGroup
                    where pr.FacilityID == facility && pr.IsDelete == false
                    select new DrugGroupModel
                    {
                        GroupTypeID = pr.GroupTypeID ,
                        GroupTypeName = pr.GroupTypeName

                    }
                ).ToList();

            return DurgGroup;
        }


        public List<ClinicAdminModel> GetFacility(string facility)
        {
            var Getfac = (from f in _healthcareContext.SHclnClinicAdmin
                          where f.FacilityID == facility && f.StrIsDelete == false
                          select new ClinicAdminModel
                          {
                              FacilityID = f.FacilityID,
                              ClinicName = f.ClinicName
                          }
                ).ToList();

            return Getfac;
        }

        public List<DrugInventoryModel> Getdruginv(string facility)
        {
            var getDruginv = (from f in _healthcareContext.SHstkDrugInventory
                              where f.FacilityID == facility && f.IsDelete == false
                          select new DrugInventoryModel
                          {
                             DrugId= f.DrugId,
                             ModelName = f.ModelName,
                          }
                ).ToList();

            return getDruginv;
        }


    }

}
