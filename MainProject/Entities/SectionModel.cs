namespace MainProject.Entities
{
    public class SectionModel
    {
        public string SecID { get; set; }
        public string SecTitle { get; set; }
        public decimal OverHead { get; set; } = 0;
        public byte PerCentage { get; set; }
        public short CountOfSell { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive => !IsDeleted;
        public string CreatedByUserID { get; set; }
        public bool isDeleted { get; set; }
    }
}


