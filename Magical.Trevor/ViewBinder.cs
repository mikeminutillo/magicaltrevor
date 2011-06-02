using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using Magical.Trevor.Controls;

namespace Magical.Trevor
{
    public interface IViewBinder
    {
        IDisposable Bind(Control view, object viewModel);
    }

    class ViewBinder : IViewBinder
    {
        private IDictionary<Type, IBinder> _binders;

        public ViewBinder(IDictionary<Type, IBinder> binders)
        {
            _binders = binders;
        }

        public IDisposable Bind(Control view, object viewModel)
        {
            var binding = new Lifetime();

            foreach (var ctl in GetAllControls(view))
            {
                var binder = GetBinderFor(ctl.GetType());
                binder.Bind(binding, ctl, viewModel);
            }

            return binding;
        }

        private IBinder GetBinderFor(Type type)
        {
            IBinder result;
            if (_binders.TryGetValue(type, out result))
                return result;
            _binders[type] = NullBinder.Instance;
            return _binders[type];
        }

        private IEnumerable<Control> GetAllControls(Control root)
        {
            if (root != null)
            {
                foreach (var ctl in root.Controls.Cast<Control>())
                {
                    yield return ctl;
                    foreach (var child in GetAllControls(ctl))
                        yield return child;
                }
            }
        }
    }
}
