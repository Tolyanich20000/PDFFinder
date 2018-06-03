using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using iTextSharp.text.pdf;

namespace PDFFinder.ViewModel
{
    using Models;
    using DataBaseContext;

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        //private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private PdfReader _pdfReader;

        public Document Document { get; set; }

        public MainWindowViewModel()
        {
            Document = new Document();
            OpenDocument();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void ShowOpenWithDialog(string path)
        {
            var args = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "shell32.dll");
            args += ",OpenAs_RunDLL " + path;
            Process.Start("rundll32.exe", args);
        }

        private void OpenDocument()
        {
            try
            {
                if (App.path != null && App.path != string.Empty)
                {
                    _pdfReader = new PdfReader(App.path);
                    //var doc = _unitOfWork.DocumentRepository.Get(_pdfReader.Info["Title"]);
                    //if (doc != null)
                    //{
                    //    Document = doc;
                    //}
                    //else
                    //{
                        Document.ReportName = _pdfReader.Info["Title"];
                        ShowOpenWithDialog(App.path);
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
