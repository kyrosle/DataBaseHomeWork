namespace HomeWork.Share.Dtos
{
    public class StaffDto
    {
        public StaffDto() { }
        public StaffDto(int id, string name, DateTime brith, string politicalType, string? health, string? postName, string? departmentName, float? salary, string? introduce)
        {
            Id = id;
            Name = name;
            Brith = brith;
            PoliticalType = politicalType;
            Health = health;
            PostName = postName;
            DepartmentName = departmentName;
            Salary = salary;
            Introduce = introduce;
        }
        // 员工 ID
        public int Id { get; set; }
        // 员工 名称
        public string Name { get; set; }
        // 员工 生日
        public DateTime Brith { get; set; }
        // 员工 政治面貌
        public int PoliticalTypeId { get; set; }
        public string PoliticalType { get; set; }
        // 员工 健康情况
        public string? Health { get; set; }
        // 员工 岗位 
        public int? PostId { get; set; }
        public string? PostName { get; set; }
        // 员工 部门 
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
        public float? Salary { get; set; }
        public string? Introduce { get; set; }
    }
}
