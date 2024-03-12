using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Model;

namespace Task2.Repositories
{
    interface IUserRepository
    {
        User GetUserByIdAndDomain(Guid userid, string domain);
        List<User> GetUsersPagination(string domain, int page, int limit);
        List<User> GetUsersByDomainAndTag(string domain, string tag);
    }
}
