namespace HomeWork.Share.Dtos
{
    public class DepartmentDto : IdentityDto
    {
        public StaffDto Manager { get; set; }
    }
}
