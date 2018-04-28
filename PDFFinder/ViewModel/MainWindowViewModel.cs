using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;

namespace PDFFinder.ViewModel
{
    public class MainWindowViewModel
    {


        public MainWindowViewModel()
        {
            var file = new PdfReader(App.path);
            if (file.Info["Title"] != string.Empty && file.Info["Title"] != null)
            {

            }
        }
    }
}
