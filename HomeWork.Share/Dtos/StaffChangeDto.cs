namespace HomeWork.Share.Dtos
{
    public class StaffChangeDto
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public DateTime ChangeTime { get; set; }
    }
}
