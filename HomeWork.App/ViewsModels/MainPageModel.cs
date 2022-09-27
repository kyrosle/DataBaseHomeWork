using System.Collections.ObjectModel;
using System.ComponentModel;

namespace HomeWork.App.ViewsModels
{
    public partial class MainPageModel : Base
    {
        private ObservableCollection<ShowBar> showBars;
        public MainPageModel()
        {
            InitShowBars();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void InitShowBars()
        {
            ShowBars = new ObservableCollection<ShowBar>()
            {
                new ShowBar() {Name="HHH"},
                new ShowBar() {Name="HHH"},
                new ShowBar() {Name="HHH"},
                new ShowBar() {Name="HHH"},
            };
        }
    }
    public class ShowBar
    {
        public string Name { get; set; }
    }

}
