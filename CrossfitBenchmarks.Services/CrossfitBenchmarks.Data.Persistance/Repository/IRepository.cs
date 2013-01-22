using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossfitBenchmarks.Data.Persistance
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        T Find(params object[] keyValues);
    }
}

