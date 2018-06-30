using System.Collections.Generic;
using System.Linq;
using EF6CodeFirstDemo.Enums;
using SMSApp.Core.Repositories;
using SMSApp.DataAccess;

namespace SMSApp
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(AppContext context)
            : base(context)
        {

        }

        /// <summary>
        /// Check permission (when the user acts with permission related activities)
        /// </summary>
        /// <param name="user"></param>
        /// <param name="permission"></param>
        /// <returns></returns>
        public bool CheckPermission(User user, UserPermissions permission)
        {
            var temp = (ApplicationContext.Users.Find(user.UserId));
            return (temp.Permissions & (int)permission) != 0;

        }

        /// <summary>
        /// Get user by name (search)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IEnumerable<User> FindWithName(string name)
        {
            return ApplicationContext.Users
                .Where(a => a.Name == name);
        }

        /// <summary>
        /// Get user by login (sign up)
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public User GetByLogin(string login)
        {
            return ApplicationContext.Users
                .Where(a => a.Login == login).First();
        }

        /// <summary>
        /// Retrieve the most recent 10 users
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetRecentUsers()
        {
            return ApplicationContext.Users
                .OrderByDescending(u => u.CreatedDate)
                .Take(10);
        }

        /// <summary>
        /// Context
        /// </summary>
        public AppContext ApplicationContext { get => mContext as AppContext; }
    }
}
