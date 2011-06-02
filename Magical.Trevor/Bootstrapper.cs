using System.Threading;
using System.Windows.Forms;
using Magical.Trevor.Controls;
using System.Collections.Generic;
using System;
using Magical.Trevor.Binders;

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
            return new ViewBinder(CreateBinders());
        }

        protected virtual IDictionary<Type, IBinder> CreateBinders()
        {
            return new Dictionary<Type, IBinder>
            {
                { typeof(TextBox), new TextBoxBinder() }, 
                { typeof(Button), new ButtonBinder() }, 
                { typeof(Placeholder), new PlaceholderBinder() }
            };
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
