namespace HealthCare.Models
{
    public class DrugInventoryModel
    {

        public DrugInventoryModel() { }

        private String drugId;           
        private String modelName;
        private String categoryId;
        private String typeId;
        private String rockId;
        private String medicalDescription;
        private String price;
        private String sideEffects;
        private String therapy;
        private String user;
        private String company;
        private String barCode;
        private String groupType;
        private String groupName;
        private String LastupdatedUser;
        private String LastupdatedDate;
        private String LastUpdatedMachine;
        private String dosage;

      
       
        public string ModelName { get => modelName; set => modelName = value; }
        public string CategoryId { get => categoryId; set => categoryId = value; }
        public string TypeId { get => typeId; set => typeId = value; }
        public string RockId { get => rockId; set => rockId = value; }
        public string Price { get => price; set => price = value; }
        public string SideEffects { get => sideEffects; set => sideEffects = value; }
        public string Therapy { get => therapy; set => therapy = value; }
        public string User { get => user; set => user = value; }
        public string Company { get => company; set => company = value; }
        public string BarCode { get => barCode; set => barCode = value; }
        public string GroupType { get => groupType; set => groupType = value; }
        public string GroupName { get => groupName; set => groupName = value; }
        public string LastupdatedUser1 { get => LastupdatedUser; set => LastupdatedUser = value; }
        public string LastupdatedDate1 { get => LastupdatedDate; set => LastupdatedDate = value; }
        public string LastUpdatedMachine1 { get => LastUpdatedMachine; set => LastUpdatedMachine = value; }
        public string MedicalDescription { get => medicalDescription; set => medicalDescription = value; }
        public string DrugId { get => drugId; set => drugId = value; }
        public string Dosage { get => dosage; set => dosage = value; }
    }
}
