using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Share.Dtos
{
    internal class SalaryRecordDto
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public string StaffName { get; set; }
        public float BasicSalary { get; set; }
        public float Bouns { get; set; }
        public float Fine { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime CutOfTime { get; set; }
    }
}
