namespace HomeWork.api.Models
{
    public class Staff : IdentityModel
    {
        // 员工 ID

        // 员工 名称

        // 员工 生日
        public DateTime Brith { get; set; }
        // 员工 政治面貌
        public int PoliticalType { get; set; }
        // 员工 健康情况
        public string? Health { get; set; }
        // 员工 岗位 
        public int? PostId { get; set; }
        // 员工 部门 
        public int? DepartmentId { get; set; }
        // 员工 薪资
        public int? SalaryId { get; set; }
        // 员工 介绍
        public string? Introduce { get; set; }
    }
}
