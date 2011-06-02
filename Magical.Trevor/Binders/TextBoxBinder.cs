using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Magical.Trevor.Binders
{
    public class TextBoxBinder : Binder<TextBox>
    {
        protected override void BindCore(Lifetime lifetime, TextBox ctl, object viewModel)
        {
            var properties = TypeDescriptor.GetProperties(viewModel)
                .OfType<PropertyDescriptor>()
                .ToLookup(x => x.Name, x => x)
                ;

            var textProperty = properties[ctl.Name].FirstOrDefault();
            if (textProperty != null && textProperty.PropertyType == typeof(string))
            {
                lifetime.Add(CreateBinding(ctl, "Text", viewModel, textProperty.Name));
            }
        }
    }
}
