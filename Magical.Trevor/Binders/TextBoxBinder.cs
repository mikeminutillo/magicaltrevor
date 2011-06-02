using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Magical.Trevor.Binders
{
    public class TextBoxBinder : Binder
    {
        protected override IDisposable BindCore(Control ctl, object viewModel)
        {
            var binding = new Lifetime();

            var properties = TypeDescriptor.GetProperties(viewModel)
                .OfType<PropertyDescriptor>()
                .ToLookup(x => x.Name, x => x)
                ;

            var textProperty = properties[ctl.Name].FirstOrDefault();
            if (textProperty != null && textProperty.PropertyType == typeof(string))
            {
                binding.Add(AddBinding(ctl, "Text", viewModel, textProperty.Name));
            }

            return binding;
        }
    }
}
