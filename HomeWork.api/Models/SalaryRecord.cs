namespace HomeWork.Api.Models
{
    public class SalaryRecord
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public float Salary { get; set; }
        public float BasicSalary { get; set; }
        public float Bouns { get; set; }
        public float Fine { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime CutOfTime { get; set; }
        public bool IsDeleted { get; set; }

    }
}
