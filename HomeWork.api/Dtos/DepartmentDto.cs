namespace HomeWork.api.Dtos
{
    public class DepartmentDto : IdentityDto
    {
        public StaffDto Manger { get; set; }
    }
}
