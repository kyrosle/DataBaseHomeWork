using HomeWork.api.Dtos.Datadictionary;
using HomeWork.api.Models;

namespace HomeWork.api.Dtos
{
    public class StaffDto : IdentityDto
    {
        // 员工 ID

        // 员工 名称

        // 员工 生日
        public DateTime Brith { get; set; }

        // 员工 政治面貌
        public Polical PoliticalType { get; set; }

        // 员工 健康情况
        public string? Health { get; set; }

        // 员工 岗位 
        public Post Post { get; set; }
        // 员工 部门 
        public string Department { get; set; }
    }
}
