using System.Collections.Generic;
using System.Linq;
using SMSApp.Enums;
using SMSApp.DataAccess;
using SMSApp.Repositories.Core;

namespace SMSApp.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(Context context)
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
            return (user.Permissions & permission) != 0;
        }

        
        /// <summary>
        /// Get user by login (sign up)
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public User GetByLogin(string login)
        {
            return mContext.Users
                .Where(a => a.Login == login).First();
        }

        public void SetPermission(User user, UserPermissions permission)
        {
            user.Permissions |= permission;
        }

        public void UnsetPermission(User user, UserPermissions permission)
        {
            user.Permissions = user.Permissions & ~(permission);
        }

        public void ResetPermission(User user)
        {
            user.Permissions = 0;
        }

        public bool AuthUser(string login, string pwd)
        {
            throw new System.NotImplementedException();
        }

    }
}
