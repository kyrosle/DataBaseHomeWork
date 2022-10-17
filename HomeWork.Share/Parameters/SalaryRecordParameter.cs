using HomeWork.Share.Parmeters;

namespace HomeWork.Share.Parameters
{
    public class SalaryRecordParameter : QueryParameter
    {
        public int? SelectStaffs { get; set; }
        public string? StaffName { get; set; }
        public int? OrderKey { get; set; }
        public int? OrderTimeKey { get; set; }
    }
}
