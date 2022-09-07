namespace HomeWork.api.Models
{
    public class AttendanceStatus : EnumModel
    {
        // 奖罚
        public int FineOrBouns { get; set; }
        // 奖罚的比率
        public float RateFineOrBouns { get; set; }
    }
}
