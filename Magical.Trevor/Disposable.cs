using System;

namespace Magical.Trevor
{
    class Disposable : IDisposable
    {
        private readonly Action _action;

        private Disposable(Action action)
        {
            _action = action;
        }

        public static IDisposable Create(Action action)
        {
            return new Disposable(action);
        }

        public void Dispose()
        {
            _action();
        }
    }
}
