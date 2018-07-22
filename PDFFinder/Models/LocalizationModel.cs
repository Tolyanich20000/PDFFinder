using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFFinder.Models
{
    public class LocalizationModel:INotifyPropertyChanged
    {

        private string _apply;
        private string _duplex;
        private string _filename;
        private string _labelsetitings;
        private string _paperFormat ;
        private string _printername ;
        private string _programname;
        private string _documentSetiings;


        public string Apply
        {
            get { return _apply; }
                        
            set
            {
                if (_apply != value)
                {
                    _apply = value;
                    OnPropertyChanged("Apply");
                }
            }


        }
        public string Duplex
        {
            get { return _duplex; }
            set
            {
                if (_duplex != value)
                {

                    _duplex = value;
                    OnPropertyChanged("Duplex");
                }
            }
        }
        public string FileName
        {
            get { return _filename; }
            set
            {
                if (_filename != value)
                {

                    _filename = value;
                    OnPropertyChanged("FileName");
                }


            }
        }
        public string LabelSettings
        {
            get { return _labelsetitings; }
            set
            {
                if (_labelsetitings != value)
                {
                    _labelsetitings = value;
                    OnPropertyChanged("LabelSettings");
                }
            }
        }
        public string PaperFormat
        {
            get { return _paperFormat; }
            set
            {
                if (_paperFormat != value)
                {
                    _paperFormat = value;
                    OnPropertyChanged("PaperFormat");
                }
            }
        }
        public string PrinterName
        {
            get { return _printername; }
            set
            {
                if (_printername != value)
                {
                    _printername = value;
                    OnPropertyChanged("PrinterName");
                }
            }
        }
        public string ProgramName
        {
            get { return _programname; }
            set
            {
                if (_programname != value)
                {

                    _programname = value;
                    OnPropertyChanged("ProgramName");
                }
            }


        }
        public string DocumentSettings
        {
            get { return _documentSetiings; }
            set
            {
                if (_documentSetiings != value)
                {
                    _documentSetiings = value;
                    OnPropertyChanged("DocumentSettings");
                }
            }


        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
