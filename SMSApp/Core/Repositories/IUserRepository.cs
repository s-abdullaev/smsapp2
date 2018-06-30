using EF6CodeFirstDemo.Enums;
using SMSApp.DataAccess;
using System.Collections.Generic;

namespace SMSApp.Core.Repositories
{
    public interface IUserRepository:IRepository<User>
    {
        /// <summary>
        /// Check if the user has the certain permission
        /// </summary>
        /// <param name="user">user to check</param>
        /// <param name="permission">permission to check</param>
        /// <returns></returns>
        bool CheckPermission(User user,UserPermissions permission);

        /// <summary>
        /// Gets the recent 10 users
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetRecentUsers();

        /// <summary>
        /// Finds the users with certain name (Can be used in searches)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IEnumerable<User> FindWithName(string name);

        /// <summary>
        /// Finds the user with certain login (Can be used for signing up)
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        User GetByLogin(string login);
    }
}
