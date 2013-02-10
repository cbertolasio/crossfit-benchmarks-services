using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossfitBenchmarks.Data.DataTransfer;

namespace CrossfitBenchmarks.Data.Persistance
{
    public interface IUserRepository : IRepository<User>
    {
        UserInfoDto GetUserInfo(string nameIdentifier, string identityProvider);
    }
}

