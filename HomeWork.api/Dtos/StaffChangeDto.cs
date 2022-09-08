namespace HomeWork.api.Dtos
{
    public class StaffChangeDto
    {
        // 变更 员工
        public StaffDto Staff { get; set; }
        // 变更 部门
        public DepartmentDto Department { get; set; }

        // 记录时间
        public DateTime ChangeTime { get; set; }
    }
}
