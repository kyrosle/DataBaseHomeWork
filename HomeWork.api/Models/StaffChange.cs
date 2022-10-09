namespace HomeWork.api.Models
{
    public class StaffChange
    {
        // 信息 Id
        public int Id { get; set; }
        // 变更 员工
        public int StaffId { get; set; }
        // 变更 部门
        public int PostId { get; set; }
        public int DepartmentId { get; set; }

        // 记录时间
        public DateTime ChangeTime { get; set; }
    }
}
