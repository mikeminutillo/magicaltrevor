using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Magical.Trevor
{
    public interface IBinder
    {
        void Bind(Lifetime lifetime, Control ctl, object viewModel);
    }

    public abstract class Binder<TControl> : IBinder where TControl : Control
    {
        void IBinder.Bind(Lifetime lifetime, Control ctl, object viewModel)
        {
            BindCore(lifetime, (TControl)ctl, viewModel);
        }

        protected abstract void BindCore(Lifetime lifetime, TControl ctl, object viewModel);

        protected IDisposable CreateBinding(Control c, string controlProperty, object source, string sourceProperty)
        {
            var binding = new Binding(controlProperty, source, sourceProperty);
            c.DataBindings.Add(binding);
            return Disposable.Create(() => c.DataBindings.Remove(binding));
        }
    }

    public sealed class NullBinder : IBinder
    {
        public static IBinder Instance = new NullBinder();

        private NullBinder() { }

        public void Bind(Lifetime lifetime, Control ctl, object viewModel)
        {
            // Do Nothing
        }
    }
}
