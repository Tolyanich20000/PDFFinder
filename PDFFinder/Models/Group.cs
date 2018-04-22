using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel;

namespace PDFFinder.Models
{
    public class Group : INotifyPropertyChanged
    {
        private string _printerName;
        private bool? _duplex;
        private PaperFormat? _paperFormat;

        public int Id { get; set; }

        public string GroupName { get; set; }

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

        public bool? Duplex
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

        public PaperFormat? PaperFormat
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

        public ICollection<Document> Documents { get; set; }

        public Group()
        {
            Documents = new List<Document>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }

    public class GroupConfiguration : EntityTypeConfiguration<Group>
    {
        public GroupConfiguration()
        {
            HasKey(e => e.Id);
            Property(e => e.GroupName).HasMaxLength(100).IsOptional();
            Property(e => e.PrinterName).HasMaxLength(100).IsOptional();
            Property(e => e.Duplex).IsOptional();
            Property(e => e.PaperFormat).IsOptional();
            HasMany(e => e.Documents).WithOptional(e => e.Group).HasForeignKey(e => e.GroupId);
        }
    }
}
