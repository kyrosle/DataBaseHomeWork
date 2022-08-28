namespace HomeWork.api.Models
{
    public class Attendance
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public int AttendanceType { get; set; }
        public DateTime RecordTime { get; set; }
        public float CountTime { get; set; }
    }
}
