using HomeWork.Share.Parmeters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Share.Parameters
{
    public class AttendanceParameter : QueryParameter
    {
        public bool? IsDescending { get; set; } = false;
        public int? SelectAttendStatus { get; set; }
        public int? SelectStaffs { get; set; }
    }
}
