namespace HomeWork.Share.Dtos
{
    public class AttendanceDto
    {
        public AttendanceDto() { }
        public AttendanceDto(int id, string staffName, string attendanceStatus, DateTime recordTime, float countTime)
        {
            Id = id;
            StaffName = staffName;
            AttendanceStatus = attendanceStatus;
            RecordTime = recordTime;
            CountTime = countTime;
        }

        public int Id { get; set; }
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public int AttendanceType { get; set; }
        public string AttendanceStatus { get; set; }
        public DateTime RecordTime { get; set; }
        public float CountTime { get; set; }
    }
}
