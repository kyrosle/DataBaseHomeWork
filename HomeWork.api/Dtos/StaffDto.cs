using HomeWork.api.Dtos.Datadictionary;

namespace HomeWork.api.Dtos
{
    public class StaffDto : IdentityDto
    {
        // 员工 ID

        // 员工 名称

        // 员工 生日
        public DateTime Brith { get; set; }

        // 员工 政治面貌
        public Political PoliticalType { get; set; }

        // 员工 健康情况
        public string? Health { get; set; }

        // 员工 岗位 
        public PostDto Post { get; set; }
        // 员工 部门 
        public DepartmentDto Department { get; set; }
    }
}
