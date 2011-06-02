using System;
using Magical.Trevor;
using Sample.App.Views;

namespace Sample.App
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            new Bootstrapper<ShellViewModel>().Run();
        }
    }
}
