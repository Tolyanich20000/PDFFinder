using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFFinder.DataBaseContext
{

    /// <summary>
    /// Main class to work with Database
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        private PDFFinderContext _finderContext = new PDFFinderContext();
        private DocumentRepository _documentRepository;
        private GroupRepository _groupRepository;
        private PaperFormatRepository _paperFormatRepository;

        public DocumentRepository DocumentRepository
        {
            get
            {
                if (_documentRepository == null)
                {
                    _documentRepository = new DocumentRepository(_finderContext);
                }
                return _documentRepository;
            }
        }

        public GroupRepository GroupRepository
        {
            get
            {
                if (_groupRepository == null)
                {
                    _groupRepository = new GroupRepository(_finderContext);
                }
                return _groupRepository;
            }
        }

        public PaperFormatRepository PaperFormatRepository
        {
            get
            {
                if (_paperFormatRepository == null)
                {
                    _paperFormatRepository = new PaperFormatRepository(_finderContext);
                }
                return _paperFormatRepository;
            }
        }

        public void Save()
        {
            _finderContext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _finderContext.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
