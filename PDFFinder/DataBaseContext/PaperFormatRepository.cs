using PDFFinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFFinder.DataBaseContext
{
    public class PaperFormatRepository : IRepository<PaperFormat>
    {
        private readonly PDFFinderContext _context;

        public PaperFormatRepository(PDFFinderContext context)
        {
            _context = context;
        }

        public void Create(PaperFormat item)
        {
            _context.PaperFormats.Add(item);
        }

        public void Delete(int id)
        {
            PaperFormat item = _context.PaperFormats.Find(id);
            if (item != null)
            {
                _context.PaperFormats.Remove(item); 
            }
        }

        public void Delete(string name)
        {
            PaperFormat item = _context.PaperFormats.FirstOrDefault(e => e.Name == name);
            if (item != null)
            {
                _context.PaperFormats.Remove(item);
            }
        }

        public PaperFormat Get(int id)
        {
            return _context.PaperFormats.Find(id);
        }

        public PaperFormat Get(string name)
        {
            return _context.PaperFormats.FirstOrDefault(e => e.Name == name);
        }

        public IEnumerable<PaperFormat> GetAll()
        {
            return _context.PaperFormats.ToList();
        }

        public void Update(PaperFormat item)
        {
            _context.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
