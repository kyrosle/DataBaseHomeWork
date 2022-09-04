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
        //public Post Post { get; set; }
        // 员工 岗位 ID
        public int PostId { get; set; }
        // 员工 部门 
        //public Department Department { get; set; }
        // 员工 部门 ID
        public int DepartmentId { get; set; }
    }
}
