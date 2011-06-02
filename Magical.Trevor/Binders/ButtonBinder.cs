using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Magical.Trevor.Binders
{
    class ButtonBinder : Binder<Button>
    {
        protected override void BindCore(Lifetime lifetime, Button ctl, object viewModel)
        {
            var vmType = TypeDescriptor.GetReflectionType(viewModel);

            var method = vmType.GetMethod(ctl.Name, new Type[0]);

            if (method != null)
            {
                EventHandler clicked = (s, e) => method.Invoke(viewModel, null);
                
                ctl.Click += clicked;

                lifetime.Add(Disposable.Create(() => ctl.Click -= clicked));
            }
        }
    }
}
