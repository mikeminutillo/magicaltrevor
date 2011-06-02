using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Magical.Trevor
{
    sealed class Lifetime : IDisposable
    {
        private readonly IList<object> _objects = new List<object>();
        private readonly object _lock = new object();

        public void Add(object obj)
        {
            lock(_lock)
                _objects.Add(obj);
        }

        public void Flush()
        {
            lock (_lock)
            {
                _objects.OfType<IDisposable>().Reverse().Apply(o => o.Dispose());
                _objects.Clear();
            }
        }

        void IDisposable.Dispose()
        {
            Flush();
        }
    }
}
