using System.Windows;
using iTextSharp.text.pdf;

namespace PDFFinder
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static string path;
        protected override void OnStartup(StartupEventArgs e)
        {
            foreach (string arg in e.Args)
            {
                path = arg;
            }
            base.OnStartup(e);
        }
    }
}
