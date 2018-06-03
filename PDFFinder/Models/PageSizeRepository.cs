using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Pdf;

namespace PDFFinder.Models
{
    class PageSizeRepository
    {
        private readonly List<SizeF> pageFormats;
        public PageSizeRepository()
        {
            pageFormats = new List<SizeF>();
        }

        private void SetList()
        {
            #region formats
            pageFormats.Add(PdfPageSize.A0);
            pageFormats.Add(PdfPageSize.A1);
            pageFormats.Add(PdfPageSize.A2);
            pageFormats.Add(PdfPageSize.A3);
            pageFormats.Add(PdfPageSize.A4);
            pageFormats.Add(PdfPageSize.A5);
            pageFormats.Add(PdfPageSize.A6);
            pageFormats.Add(PdfPageSize.A7);
            pageFormats.Add(PdfPageSize.A8);
            pageFormats.Add(PdfPageSize.A9);
            pageFormats.Add(PdfPageSize.A10);
            pageFormats.Add(PdfPageSize.ArchA);
            pageFormats.Add(PdfPageSize.ArchB);
            pageFormats.Add(PdfPageSize.ArchC);
            pageFormats.Add(PdfPageSize.ArchD);
            pageFormats.Add(PdfPageSize.ArchE);
            pageFormats.Add(PdfPageSize.B0);
            pageFormats.Add(PdfPageSize.B1);
            pageFormats.Add(PdfPageSize.B2);
            pageFormats.Add(PdfPageSize.B3);
            pageFormats.Add(PdfPageSize.B4);
            pageFormats.Add(PdfPageSize.B5);
            pageFormats.Add(PdfPageSize.Flsa);
            pageFormats.Add(PdfPageSize.HalfLetter);
            pageFormats.Add(PdfPageSize.Ledger);
            pageFormats.Add(PdfPageSize.Legal);
            pageFormats.Add(PdfPageSize.Letter);
            pageFormats.Add(PdfPageSize.Letter11x17);
            pageFormats.Add(PdfPageSize.Note);
            #endregion
        }

        public List<SizeF> GetAll()
        {
            return pageFormats;
        }
    }
}
