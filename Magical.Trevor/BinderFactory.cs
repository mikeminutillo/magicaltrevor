using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Magical.Trevor
{
    public interface IBinder
    {
        IDisposable Bind(Control ctl, object viewModel);
    }

    public abstract class Binder : IBinder
    {
        IDisposable IBinder.Bind(Control ctl, object viewModel)
        {
            return BindCore(ctl, viewModel);
        }

        protected abstract IDisposable BindCore(Control ctl, object viewModel);

        protected IDisposable AddBinding(Control c, string controlProperty, object source, string sourceProperty)
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

        public IDisposable Bind(Control ctl, object viewModel)
        {
            return Disposable.Create(DoNothing);
        }

        private static void DoNothing() { }
    }
}
