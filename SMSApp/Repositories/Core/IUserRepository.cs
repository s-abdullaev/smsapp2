using SMSApp.Enums;
using SMSApp.DataAccess;
using System.Collections.Generic;

namespace SMSApp.Repositories.Core
{
    public interface IUserRepository:IRepository<User>
    {
        /// <summary>
        /// Check if the user has the certain permission
        /// </summary>
        /// <param name="user">user to check</param>
        /// <param name="permission">permission to check</param>
        /// <returns></returns>
        bool CheckPermission(User user, UserPermissions permission);
        void ChangePermission(User user, UserPermissions permissions, bool val);

        bool AuthUser(string login, string pwd);
        User CurrentUser();

        /// <summary>
        /// Finds the user with certain login (Can be used for signing up)
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        User GetByLogin(string login);
    }
}
