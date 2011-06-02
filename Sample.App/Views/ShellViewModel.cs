using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Magical.Trevor;
using System.Windows.Forms;
using Sample.App.Views.Search;

namespace Sample.App.Views
{
    class ShellViewModel : NotifiesOfPropertyChangeOnUiThread
    {
        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; NotifyPropertyChanged("FullName");  }
        }

        public ShellViewModel()
        {
            Main = new SearchViewModel();
        }

        public void Go()
        {
            MessageBox.Show(FullName);
        }

        private object _main;

        public object Main
        {
            get { return _main; }
            set { _main = value; NotifyPropertyChanged("Main"); }
        }
    }
}
