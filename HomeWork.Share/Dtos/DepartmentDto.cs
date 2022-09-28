namespace HomeWork.Share.Dtos
{
    public class DepartmentDto : IdentityDto
    {
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
    }
}
