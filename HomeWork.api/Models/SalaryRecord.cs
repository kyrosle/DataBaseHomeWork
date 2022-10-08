namespace HomeWork.Api.Models
{
    public class SalaryRecord
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public float Salary { get; set; }
        public DateTime BillingTime { get; set; }
    }
}
