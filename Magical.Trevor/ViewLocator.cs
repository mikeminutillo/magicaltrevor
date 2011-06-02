using System;
using System.ComponentModel;
using System.Windows.Forms;
using Magical.Trevor.Controls;

namespace Magical.Trevor
{
    public interface IViewLocator
    {
        Control GetViewForModel(object model);
    }

    public class ViewLocator : IViewLocator
    {
        public Control GetViewForModel(object model)
        {
            var modelType = TypeDescriptor.GetReflectionType(model);

            return GetViewForModelType(modelType)
                ?? new NotFound { ExpectedViewType = modelType.Name };
        }

        protected Control GetViewForModelType(Type modelType)
        {
            var viewType = GetViewTypeForModelType(modelType);
            return CreateView(viewType);
        }

        private Control CreateView(Type viewType)
        {
            if(typeof(Control).IsAssignableFrom(viewType))
                return (Control)Activator.CreateInstance(viewType);
            return null;
        }

        protected Type GetViewTypeForModelType(Type modelType)
        {
            var viewTypeName = modelType.FullName.Replace("Model", String.Empty);
            // NOTE: This implementation forces views and view models to be the same assembly
            var viewType = modelType.Assembly.GetType(viewTypeName, false, true);
            return viewType;
        }
    }
}
