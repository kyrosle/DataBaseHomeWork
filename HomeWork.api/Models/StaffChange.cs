namespace HomeWork.api.Models
{
    public class StaffChange
    {
        // 变更 员工
        //public Staff Staff { get; set; }
        // 变更 员工 ID
        public int StaffId { get; set; }
        // 变更 部门
        //public Department Department { get; set; }
        // 变更 部门 ID
        public int DepartmentId { get; set; }

        // 记录时间
        public DateTime ChangeTime { get; set; }
    }
}
