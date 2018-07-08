using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
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
    using iTextSharp.text;

    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly UnitOfWork _unitOfWork = new UnitOfWork();
        private PdfReader _pdfReader;
        private Models.Document _document;

        public Models.Document Document
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

        public BindingList<string> Printers { get; set; }

        public BindingList<PaperFormat> Formats { get; set; }

        public DelegateCommand Apply { get; set; }

        public DelegateCommand Open { get; set; }

        public MainWindowViewModel()
        {
            GetPrinters();
            GetPaperFormats();
            Apply = new DelegateCommand(ApplyMethod, ApplyPredicate);
            Open = new DelegateCommand(OpenDocumentMethod, (object param)=> { return true; });
            if (!_unitOfWork.PaperFormatRepository.GetAll().Any())
            {
                FillPageSize();
            }
            if (App.path != null && App.path != string.Empty)
            {
                Document = new Models.Document();
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
                    Document.LastViewDateTime = DateTime.Now;
                    Document.Views++;
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
            Document.LastPrintDateTime = DateTime.Now;
            Document.Prints++;
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

        private void FillPageSize()
        {
            Type type = typeof(PageSize);
            var list = type.GetFields();
            foreach (var item in list)
            {
                _unitOfWork.PaperFormatRepository.Create(new PaperFormat()
                {
                    Name = item.Name
                });
            }
            _unitOfWork.Save();
        }

        private void GetPrinters()
        {
            Printers = new BindingList<string>();
            var printers = new ManagementObjectSearcher("SELECT * from Win32_Printer");
            foreach (var item in printers.Get())
            {
                Printers.Add(item.GetPropertyValue("Name").ToString());
            }
        }

        private void GetPaperFormats()
        {
            Formats = new BindingList<PaperFormat>();
            var formats = _unitOfWork.PaperFormatRepository.GetAll();
            foreach (var item in formats)
            {
                Formats.Add(item);
            }
        }
    }
}
