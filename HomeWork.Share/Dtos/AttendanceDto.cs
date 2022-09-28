namespace HomeWork.Share.Dtos
{
    public class AttendanceDto
    {
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public int AttendanceType { get; set; }
        public string AttendanceStatus { get; set; }
        public int FineOrBouns { get; set; }
        public float RateFineOrBouns { get; set; }
        public DateTime RecordTime { get; set; }
        public float CountTime { get; set; }
    }
}
