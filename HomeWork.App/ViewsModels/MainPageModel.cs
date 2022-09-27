using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HomeWork.App.ViewsModels
{
    internal class MainPageModel : BindableBase
    {
        public ObservableCollection<ShowBar> ShowBars
        {
            get { return showBars; }
            set { showBars = value; OnPropertyChanged(); }
        }
        ObservableCollection<ShowBar> showBars;
        public MainPageModel()
        {
            InitShowBars();
        }
        void InitShowBars()
        {
            showBars = new()
            {
                new ShowBar() { Name = "HHH" },
                new ShowBar() { Name = "HHH" },
                new ShowBar() { Name = "HHH" },
                new ShowBar() { Name = "HHH" },
                new ShowBar() { Name = "HHH" }
            };
        }
    }

    public class ShowBar
    {
        public string Name { get; set; }
    }
}
