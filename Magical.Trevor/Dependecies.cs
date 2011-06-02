using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Magical.Trevor
{
    static class Dependecies
    {
        public static IViewLocator ViewLocator { get; set; }
        public static IViewBinder ViewBinder { get; set; }
    }
}
