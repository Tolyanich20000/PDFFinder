using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFFinder.DataBaseContext
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        T Get(string name);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Delete(string name);
    }
}
