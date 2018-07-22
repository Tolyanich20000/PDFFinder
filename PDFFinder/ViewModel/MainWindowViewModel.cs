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
    using iTextSharp.text;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using TallComponents.PDF.Rasterizer;
    using TallComponents.PDF.Rasterizer.Configuration;

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

        public DelegateCommand Apply { get; set; }

        public DelegateCommand Open { get; set; }

        public MainWindowViewModel()
        {
            Document = new Models.Document();
            Apply = new DelegateCommand(ApplyMethod, (object param) => { return true; });
            Open = new DelegateCommand(OpenDocumentMethod, (object param)=> { return true; });
            if (!_unitOfWork.PaperFormatRepository.GetAll().Any())
            {
                FillPageSize();
            }
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
            
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                DefaultExt = ".pdf",
                Filter = "PDF files (*.pdf)|*.pdf"
            };
            bool? fileOpenResult = openFileDialog.ShowDialog();
            if (fileOpenResult != true)
            {
                return;
            }
            PrintDialog printDialog = new PrintDialog();
            printDialog.PageRangeSelection = PageRangeSelection.AllPages;
            printDialog.UserPageRangeEnabled = true;
            bool? doPrint = printDialog.ShowDialog();
            if (doPrint != true)
            {
                return;
            }
            FixedDocument fixedDocument;
            using (FileStream pdfFile = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
            {
                TallComponents.PDF.Rasterizer.Document document = new TallComponents.PDF.Rasterizer.Document(pdfFile);
                RenderSettings renderSettings = new RenderSettings();
                ConvertToWpfOptions renderOptions = new ConvertToWpfOptions { ConvertToImages = false };
                renderSettings.RenderPurpose = RenderPurpose.Print;
                renderSettings.ColorSettings.TransformationMode = ColorTransformationMode.HighQuality;
               
                fixedDocument = document.ConvertToWpf(renderSettings, renderOptions);
            }
            printDialog.PrintDocument(fixedDocument.DocumentPaginator, "Print");
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
    }
}
