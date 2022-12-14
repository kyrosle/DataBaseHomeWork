namespace HomeWork.api.Models
{
    public class Attendance
    {
        // 信息 ID
        public int Id { get; set; }
        // 员工实体
        public int StaffId { get; set; }
        // 出勤情况
        public int AttendanceStatusId { get; set; }
        // 记录的时间
        public DateTime RecordTime { get; set; }
        // 累计时间
        public float CountTime { get; set; }
    }
}
