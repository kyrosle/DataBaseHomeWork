namespace HomeWork.api.Models
{
    public class StaffChange
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime ChangeTime { get; set; }
    }
}
