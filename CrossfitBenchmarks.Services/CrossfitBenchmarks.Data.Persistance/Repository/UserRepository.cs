using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossfitBenchmarks.Data.DataTransfer;

namespace CrossfitBenchmarks.Data.Persistance
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public  UserRepository(DbContext context)
            : base(context)
        {
        }

        #region IUserRepository Members

        public UserInfoDto GetUserInfo(string nameIdentifier, string identityProvider)
        {
            var user = dbSet.Where(it => it.IpNameIdentifier == nameIdentifier && it.IdentityProvider == identityProvider).SingleOrDefault();
            if (user != null)
            {
                return new UserInfoDto { UserId = user.UserId, IdentityProvider = user.IdentityProvider,
                        NameIdentifier = user.IpNameIdentifier, FirstName = user.FirstName, LastName = user.LastName,
                        Email = user.IpEmail };

                return AutoMapper.Mapper.Map<User, UserInfoDto>(user);
            }
            else
            {
                var defaultValue = "(Unspecified)";
                var currentDate = DateTime.UtcNow;
                user = new User {
                    IpNameIdentifier = nameIdentifier,
                    IdentityProvider = identityProvider,
                    FirstName = defaultValue,
                    Email = defaultValue,
                    IpEmail = defaultValue,
                    IpName = defaultValue,
                    LastName = defaultValue,
                    TimeZoneOffset = -6,
                    DateCreated = currentDate,
                    LastActivityDate = currentDate
                };

                dbSet.Add(user);

                return context.SaveChanges() > 0 ? AutoMapper.Mapper.Map<User, UserInfoDto>(user) : null;
            }
        }

        #endregion
    }
}

