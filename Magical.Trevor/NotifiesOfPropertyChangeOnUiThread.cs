using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace Magical.Trevor
{
    public class NotifiesOfPropertyChangeOnUiThread : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            Execute.OnUiThread(() => PropertyChanged(this, new PropertyChangedEventArgs(propertyName)));
        }

        protected virtual IEnumerable<string> RefreshProps
        {
            get
            {
                return GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                    .Where(x => x.CanRead)
                    .Select(x => x.Name);
            }
        }

        protected void RefreshAllProperties()
        {
            RefreshProps.Apply(NotifyPropertyChanged);
        }
    }
}
