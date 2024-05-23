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
        public List<DrugCategoryModel> GetCategoryid()
        {
            var Categoryid = (
                    from pr in _healthcareContext.SHstkDrugCategory
                    select new DrugCategoryModel
                    {
                        CategoryID = pr.CategoryID
                    }

                ).ToList();
            return Categoryid;
        }


        public List<DrugTypeModel> GetDrugTypeid()
        {
            var DrugTypeid = (
                    from pr in _healthcareContext.SHstkDrugType
                    select new DrugTypeModel
                    {
                        TypeID = pr.TypeID
                    }
                ).ToList();
            return DrugTypeid;
        }

        public List<DrugGroupModel> GetDurgGroup()
        {
            var DurgGroup = (
                    from pr in _healthcareContext.SHstkDrugGroup
                    select new DrugGroupModel
                    {
                        GroupTypeID = pr.GroupTypeID ,
                        GroupTypeName = pr.GroupTypeName

                    }
                ).ToList();

            return DurgGroup;
        }



    }

}
