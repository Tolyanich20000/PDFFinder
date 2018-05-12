using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFFinder.DataBaseContext
{
    using Models;

    public class GroupRepository : IRepository<Group>
    {
        private PDFFinderContext _pdfFinderContext;

        public GroupRepository(PDFFinderContext context)
        {
            _pdfFinderContext = context;
        }

        public void Create(Group item)
        {
            _pdfFinderContext.Groups.Add(item);
        }

        public void Delete(int id)
        {
            Group group = _pdfFinderContext.Groups.Find(id);
            _pdfFinderContext.Groups.Remove(group);
        }

        public void Delete(string name)
        {
            Group group = _pdfFinderContext.Groups.FirstOrDefault(e => e.GroupName == name);
            _pdfFinderContext.Groups.Remove(group);
        }

        public Group Get(int id)
        {
            return _pdfFinderContext.Groups.Find(id);
        }

        public Group Get(string name)
        {
            return _pdfFinderContext.Groups.FirstOrDefault(e => e.GroupName == name);
        }

        public IEnumerable<Group> GetAll()
        {
            return _pdfFinderContext.Groups.ToList();
        }

        public void Update(Group item)
        {
            _pdfFinderContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
