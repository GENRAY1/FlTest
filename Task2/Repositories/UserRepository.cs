using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.AppContext;
using Task2.Model;

namespace Task2.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly ApplicationContext context;

        public UserRepository(ApplicationContext applicationContext)
        {
            this.context = applicationContext;
        }

        public User GetUserByIdAndDomain(Guid userid, string domain)
        {
           return context.Users
                .Include(u => u.TagToUsers)
                .ThenInclude(t=> t.Tag)
                .FirstOrDefault(u => u.UserId == userid && u.Domain == domain);
        }
        public List<User> GetUsersPagination(string domain, int page, int limit)
        {
            if (page <= 0 || limit <= 0) throw new Exception("Неккоректные параметры");

            var result = context.Users.Where(u => u.Domain == domain)
            .Skip((page - 1) * limit)
            .Take(limit)
            .Include(u => u.TagToUsers)
            .ThenInclude(t => t.Tag)
            .ToList();
            return result;
        }
        public List<User> GetUsersByDomainAndTag(string domain, string tag)
        {
            return context.Users.Where(u => u.TagToUsers.Any(tu => tu.Tag.Value == tag) && u.Domain == domain)
                .Include(u => u.TagToUsers)
                .ThenInclude(t => t.Tag)
                .ToList();
        }
    }
}
