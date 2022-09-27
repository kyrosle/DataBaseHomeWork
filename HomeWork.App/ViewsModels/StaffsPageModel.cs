using HomeWork.Share.Dtos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.App.ViewsModels
{
    internal class StaffsPageModel : BindableBase
    {
        private ObservableCollection<StaffDto> staffDtos;
        public ObservableCollection<StaffDto> StaffDtos
        {
            get { return staffDtos; }
            set { staffDtos = value; OnPropertyChanged(); }
        }
        public StaffsPageModel()
        {
            InitStaffDtos();
        }

        void InitStaffDtos()
        {
            staffDtos = new()
            {
                new StaffDto() {Name = "HHH"},
                new StaffDto() {Name = "HHH"},
                new StaffDto() {Name = "HHH"},
                new StaffDto() {Name = "HHH"},
            };
        }
    }
}
