using HomeWork.Share.Parmeters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.Share.Parameters
{
    public class StaffChangeParameter : QueryParameter
    {
        public bool? IsDescending { get; set; } = false;
        public int? SelectDepartment { get; set; }
        public int? SelectStaffs { get; set; }
    }
}
