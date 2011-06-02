using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Magical.Trevor
{
    public static class Execute
    {
        [ThreadStatic]
        private static bool _isUiThread;

        private static Action<Action> _onUiExec = action => action();

        public static void OnUiThread(Action action)
        {
            _onUiExec(action);
        }

        internal static void SetUiContext(SynchronizationContext synchronizationContext)
        {
            _onUiExec = action =>
            {
                if (_isUiThread)
                    action();
                else
                    synchronizationContext.Post(e => action(), null);
            };

            OnUiThread(() => _isUiThread = true);
        }
    }
}
