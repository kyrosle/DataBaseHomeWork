using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.App.ViewsModels
{
    internal class HomePageModel : BindableBase
    {
        private string welcome = "HHHHHH";

        public string Welcome
        {
            get { return welcome; }
            set { welcome = value; }
        }
    }
}
