using System.Threading;
using System.Windows.Forms;
using Magical.Trevor.Controls;

namespace Magical.Trevor
{
    public abstract class Bootstrapper
    {
        public void Run()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var rootWindow = new Window();

            // NOTE: Must be after the first form is created
            Execute.SetUiContext(SynchronizationContext.Current);

            Dependecies.ViewLocator = CreateViewLocator();
            Dependecies.ViewBinder = CreateViewBinder();

            var rootViewModel = CreateRootViewModel();

            rootWindow.SetViewModel(rootViewModel);

            Application.Run(rootWindow);
        }

        protected abstract object CreateRootViewModel();

        protected virtual IViewLocator CreateViewLocator()
        {
            return new ViewLocator();
        }

        protected virtual IViewBinder CreateViewBinder()
        {
            return new ViewBinder();
        }
    }

    public class Bootstrapper<TRootViewModel> : Bootstrapper where TRootViewModel : new()
    {
        protected override object CreateRootViewModel()
        {
            return new TRootViewModel();
        }
    }
}
