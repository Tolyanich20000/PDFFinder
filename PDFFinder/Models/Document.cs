using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel;

namespace PDFFinder.Models
{
    /// <summary>
    /// Paper format enum
    /// </summary>
    public enum PaperFormat
    {
        A4,
        A5,
        Letter
    }

    /// <summary>
    /// Document entity
    /// </summary>
    public class Document : INotifyPropertyChanged
    {
        private string _reportName;
        private string _groupName;
        private string _printerName;
        private bool _duplex;
        private PaperFormat _paperFormat;

        public int ReportId { get; set; }

        public string ReportName
        {
            get { return _reportName; }
            set
            {
                if (_reportName != value)
                {
                    _reportName = value;
                    NotifyPropertyChanged("ReportName");
                }
            }
        }

        public string GroupName
        {
            get { return _groupName; }
            set
            {
                if (_groupName != value)
                {
                    _groupName = value;
                    NotifyPropertyChanged("GroupName");
                }
            }
        }

        public string PrinterName
        {
            get { return _printerName; }
            set
            {
                if (_printerName != value)
                {
                    _printerName = value;
                    NotifyPropertyChanged("PrinterName");
                }
            }
        }

        public bool Duplex
        {
            get { return _duplex; }
            set
            {
                if (_duplex != value)
                {
                    _duplex = value;
                    NotifyPropertyChanged("Duplex");
                }
            }
        }

        public PaperFormat PaperFormat
        {
            get { return _paperFormat; }
            set
            {
                if (_paperFormat != value)
                {
                    _paperFormat = value;
                    NotifyPropertyChanged("PaperFormat");
                }
            }
        }

        public int Views { get; set; }

        public int Prints { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        } 
    }


    /// <summary>
    /// Configuration for Document entity
    /// </summary>
    class DocumentConfiguration : EntityTypeConfiguration<Document>
    {
        public DocumentConfiguration()
        {
            HasKey(e => e.ReportId);
            Property(e => e.ReportName).HasMaxLength(50).IsRequired();
            Ignore(e => e.GroupName);
            Property(e => e.PrinterName).HasMaxLength(50).IsOptional();
            Property(e => e.PrinterName).HasMaxLength(50).IsOptional();
            Property(e => e.Duplex).IsOptional();
            Property(e => e.PaperFormat).IsOptional();
            Property(e => e.Views).IsOptional();
            Property(e => e.Prints).IsOptional();
        }
    }
}
