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
    using PDFFinder.Commands;
    using Microsoft.Win32;

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private PdfReader _pdfReader;
        private Document _document;

        public Document Document
        {
            get { return _document; }
            set
            {
                if (_document != value)
                {
                    _document = value;
                    OnPropertyChanged("Document");
                }
            }
        }

        public DelegateCommand Apply { get; set; }

        public DelegateCommand Open { get; set; }

        public MainWindowViewModel()
        {
            Document = new Document();
            Apply = new DelegateCommand(ApplyMethod, ApplyPredicate);
            Open = new DelegateCommand(OpenDocumentMethod, (object param)=> { return true; });
            if (App.path != null && App.path != string.Empty)
            {
                OpenDocument(App.path);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void ShowOpenWithDialog(string path)
        {
            var args = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "shell32.dll");
            args += ",OpenAs_RunDLL " + path;
            Process.Start("rundll32.exe", args);
        }

        private void OpenDocument(string file)
        {
            try
            {
                _pdfReader = new PdfReader(file);
                var doc = _unitOfWork.DocumentRepository.Get(_pdfReader.Info["Title"]);
                if (doc != null)
                {
                    Document = doc;
                }
                else
                {
                    Document.ReportName = _pdfReader.Info["Title"];
                    ShowOpenWithDialog(App.path);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ApplyMethod(object param)
        {
            MessageBox.Show("do something");
        }

        private bool ApplyPredicate(object param)
        {
            return Document != null ? true : false;
        }

        private void OpenDocumentMethod(object param)
        {
            var file = new OpenFileDialog();
            if (file.ShowDialog() == true) 
            {
                OpenDocument(file.FileName);
            }
        }
    }
}
