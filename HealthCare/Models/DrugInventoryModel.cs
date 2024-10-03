using System.ComponentModel.DataAnnotations;

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
        private String lastupdatedUser;
        private String lastupdatedDate;
        private String lastUpdatedMachine;
        private String dosage;
        private String facilityID;
        private bool strIsDelete;
        private long id;

        [MaxLength(100)]
        public string DrugId { get => drugId; set => drugId = value; }

        [MaxLength(30)]
        public string? ModelName { get => modelName; set => modelName = value; }

        [MaxLength(100)]
        public string? CategoryId { get => categoryId; set => categoryId = value; }

        [MaxLength(100)]
        public string? TypeId { get => typeId; set => typeId = value; }

        [MaxLength(100)]
        public string? RockId { get => rockId; set => rockId = value; }

        [MaxLength(100)]
        public string? MedicalDescription { get => medicalDescription; set => medicalDescription = value; }

        [MaxLength(30)]
        public string? Price { get => price; set => price = value; }

        [MaxLength(100)]
        public string? SideEffects { get => sideEffects; set => sideEffects = value; }

        [MaxLength(30)]
        public string? Therapy { get => therapy; set => therapy = value; }

        [MaxLength(30)]
        public string? User { get => user; set => user = value; }

        [MaxLength(30)]
        public string? Company { get => company; set => company = value; }

        [MaxLength(30)]
        public string? BarCode { get => barCode; set => barCode = value; }

        [MaxLength(30)]
        public string? GroupType { get => groupType; set => groupType = value; }

        [MaxLength(30)]
        public string? GroupName { get => groupName; set => groupName = value; }

        [MaxLength(30)]
        public string? LastupdatedUser { get => lastupdatedUser; set => lastupdatedUser = value; }

        [MaxLength(30)]
        public string? LastupdatedDate { get => lastupdatedDate; set => lastupdatedDate = value; }

        [MaxLength(30)]
        public string? LastUpdatedMachine { get => lastUpdatedMachine; set => lastUpdatedMachine = value; }

        [MaxLength(30)]
        public string? Dosage { get => dosage; set => dosage = value; }

        [MaxLength(100)]
        public string FacilityID { get => facilityID; set => facilityID = value; }
        public bool IsDelete { get => strIsDelete; set => strIsDelete = value; }
        public long Id { get => id; set => id = value; }
    }
}
