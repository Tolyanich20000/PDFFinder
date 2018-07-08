using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFFinder.DataBaseContext
{
    using Models;
    using DataBaseContext;

    /// <summary>
    /// Repository for documents
    /// </summary>
    public class DocumentRepository : IRepository<Document>
    {
        private PDFFinderContext _finderContext;

        public DocumentRepository(PDFFinderContext context)
        {
            _finderContext = context;
        }

        /// <summary>
        /// Create an entity
        /// </summary>
        /// <param name="item"></param>
        public void Create(Document item)
        {
            _finderContext.Documents.Add(item);
        }

        /// <summary>
        /// Delete entity by id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            Document document = _finderContext.Documents.Find(id);
            if (document != null)
            {
                _finderContext.Documents.Remove(document);
            }
        }

        /// <summary>
        /// Delete entity by name
        /// </summary>
        /// <param name="name"></param>
        public void Delete(string name)
        {
            Document document = _finderContext.Documents.FirstOrDefault(e => e.ReportName == name);
            if (document != null)
            {
                _finderContext.Documents.Remove(document);
            }
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Document> GetAll()
        {
            return _finderContext.Documents;
        }

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Document Get(int id)
        {
            return _finderContext.Documents.Find(id);
        }

        /// <summary>
        /// Get entity by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Document Get(string name)
        {
            return _finderContext.Documents.FirstOrDefault(e => e.ReportName == name);
        }

        /// <summary>
        /// Modify entity state
        /// </summary>
        /// <param name="item"></param>
        public void Update(Document item)
        {
            _finderContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
