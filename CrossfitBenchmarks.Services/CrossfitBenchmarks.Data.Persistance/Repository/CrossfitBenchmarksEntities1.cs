using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossfitBenchmarks.Data.Persistance
{
    public partial class CrossfitBenchmarksEntities1 : IUnitOfWork
    {

        #region IUnitOfWork Members
        public void Commit()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

