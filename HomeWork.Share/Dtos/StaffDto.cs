namespace HomeWork.Share.Dtos
{
    public class StaffDto : IdentityDto
    {
        // 员工 ID

        // 员工 名称

        // 员工 生日
        public DateTime Brith { get; set; }

        // 员工 政治面貌
        public string PoliticalType { get; set; }

        // 员工 健康情况
        public string? Health { get; set; }

        // 员工 岗位 
        public int? PostId { get; set; }
        public string? PostName { get; set; }
        // 员工 部门 
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
    }
}
