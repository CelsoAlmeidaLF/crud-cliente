using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almeida.Core.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();
        T GetById(int id);
        int Set(T obj);
        int Delete(T obj);
    }
}
