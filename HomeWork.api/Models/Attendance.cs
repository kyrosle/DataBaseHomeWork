namespace HomeWork.api.Models
{
    public class Attendance
    {
        public int StaffId { get; set; }
        public int AttendanceType { get; set; }
        public DateTime RecordTime { get; set; }
        public float CountTime { get; set; }
    }
}
