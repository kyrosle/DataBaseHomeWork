using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HomeWork.App.ViewsModels
{
    internal class MainPageModel : BindableBase
    {
        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; OnPropertyChanged(); }
        }
        private string countText;

        public string CountText
        {
            get { return countText; }
            set { countText = value; OnPropertyChanged(); }
        }

        public ICommand OnCounterClicked { get; private set; }

        public MainPageModel()
        {
            OnCounterClicked = new Command(execute: () =>
            {
                count++;
                if (count == 1)
                    CountText = $"Clicked {count} time";
                else
                    CountText = $"Clicked {count} times";
            }, canExecute: () => { return true; });
        }
    }
}
