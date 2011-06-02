using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Magical.Trevor;
using System.Windows.Forms;

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

        public void Go()
        {
            MessageBox.Show(FullName);
        }
    }
}
