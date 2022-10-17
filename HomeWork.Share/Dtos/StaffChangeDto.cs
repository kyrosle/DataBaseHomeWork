namespace HomeWork.Share.Dtos
{
    public class StaffChangeDto
    {
        public StaffChangeDto() { }
        public StaffChangeDto(int id, string staffName, string postName, string departmentName, DateTime changeTime)
        {
            Id = id;
            StaffName = staffName;
            PostName = postName;
            DepartmentName = departmentName;
            ChangeTime = changeTime;
        }

        public int Id { get; set; }
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public int PostId { get; set; }
        public string PostName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public DateTime ChangeTime { get; set; }
    }
}
