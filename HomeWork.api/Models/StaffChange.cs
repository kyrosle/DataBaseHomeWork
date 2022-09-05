namespace HomeWork.api.Models
{
    public class StaffChange
    {
        // 信息 Id
        public int Id { get; set; }
        // 变更 员工
        public Staff Staff { get; set; }
        // 变更 部门
        public Department Department { get; set; }

        // 记录时间
        public DateTime ChangeTime { get; set; }
    }
}
