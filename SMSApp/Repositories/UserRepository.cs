using System.Collections.Generic;
using System.Linq;
using SMSApp.Enums;
using SMSApp.DataAccess;
using SMSApp.Repositories.Core;

namespace SMSApp.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private User _currentUser=null;

        public User CurrentUser() { return _currentUser; }

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

        public User GetByLogin(string login)
        {
            return mContext.Users
                .Where(a => a.Login == login).FirstOrDefault();
        }

        public void SetPermission(User user, UserPermissions permission)
        {
            user.Permissions |= permission;
        }

        public void UnsetPermission(User user, UserPermissions permission)
        {
            user.Permissions = user.Permissions & ~(permission);
        }

        public void ChangePermission(User user, UserPermissions permissions, bool val)
        {
            if (val)
            {
                SetPermission(user, permissions);
            } else
            {
                UnsetPermission(user, permissions);
            }
        }

        public void ResetPermission(User user)
        {
            user.Permissions = 0;
        }

        public bool AuthUser(string login, string pwd)
        {
            var user = GetByLogin(login);
            if (user !=null && user.Password==pwd)
            {
                _currentUser = user;
                return true;
            }
            return false;
        }

    }
}
