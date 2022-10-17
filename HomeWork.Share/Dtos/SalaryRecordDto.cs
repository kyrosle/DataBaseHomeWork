using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Share.Dtos
{
    public class SalaryRecordDto
    {
        public SalaryRecordDto() { }
        public SalaryRecordDto(int id, string staffName, float basicSalary, float bouns, float fine, DateTime startTime, DateTime cutOfTime)
        {
            Id = id;
            StaffName = staffName;
            BasicSalary = basicSalary;
            Bouns = bouns;
            Fine = fine;
            StartTime = startTime;
            CutOfTime = cutOfTime;
        }

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
