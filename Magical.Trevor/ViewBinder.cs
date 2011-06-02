using System;
using System.Windows.Forms;

namespace Magical.Trevor
{
    public interface IViewBinder
    {
        IDisposable Bind(Control view, object viewModel);
    }

    class ViewBinder : IViewBinder
    {
        public IDisposable Bind(Control view, object viewModel)
        {
            return Disposable.Create(() => { /* TODO: Create the binding */ });
        }
    }
}
