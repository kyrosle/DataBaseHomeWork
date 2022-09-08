namespace HomeWork.api.Dtos
{
    public class DepartmentDto : IdentityDto
    {
        public StaffDto Manager { get; set; }
    }
}
