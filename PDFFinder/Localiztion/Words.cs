using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PDFFinder.Localiztion
{
     class Words : INotifyPropertyChanged
    {
        private string apply;
        private string duplex;
        private  string filename;
        private string labelsetitings;
        private string paperFormat;
        private string printername;
        private string programname;

        public string Apply {


            get { return apply; }
            set
            {
                apply = value;
                OnPropertyChanged("Apply");
            }


        }
        public string Duplex
        {


            get { return duplex; }
            set
            {
                duplex = value;
                OnPropertyChanged("Duplex");
            }


        }
        public  string FileName
        {


            get { return filename; }
            set
            {
                filename = value;
                OnPropertyChanged("FileName");
            }


        }
        public string ProgramName
        {


            get { return programname; }
            set
            {
                programname = value;
                OnPropertyChanged("ProgramName");
            }


        }
        public string PaperFormat
        {


            get { return paperFormat; }
            set
            {
                paperFormat = value;
                OnPropertyChanged("PaperFormat");
            }


        }
        public string PrinterName
        {


            get { return printername; }
            set
            {
                printername = value;
                OnPropertyChanged("PrinterName");
            }


        }
        public string LabelSettings
        {


            get { return labelsetitings; }
            set
            {
                labelsetitings = value;
                OnPropertyChanged("LabelSettings");
            }


        }





        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }



    }
}
