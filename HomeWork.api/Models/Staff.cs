namespace HomeWork.api.Models
{
    public class Staff : IdentityModel
    {
        public DateTime Brith { get; set; }
        public int PoliticalType { get; set; }
        public string? Health { get; set; }
        public int PostId { get; set; }
        public int DepartmentId { get; set; }
    }
}
