namespace HomeWork.Share.Dtos
{
    public class DepartmentDto
    {
        public DepartmentDto() { }
        public DepartmentDto(int id, string name, string managerName)
        {
            Id = id;
            Name = name;
            ManagerName = managerName;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ManagerId { get; set; }
        public string? ManagerName { get; set; }
    }
}
