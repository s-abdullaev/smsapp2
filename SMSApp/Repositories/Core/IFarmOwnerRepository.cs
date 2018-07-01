using SMSApp.DataAccess;
using System.Collections.Generic;

namespace SMSApp.Repositories.Core
{
    public interface IFarmOwnerRepository:IRepository<FarmOwner>
    {
        /// <summary>
        /// Selects the <see cref="FarmOwner"/> in the given region (Search,Comboboxes)
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        IEnumerable<FarmOwner> GetByRegion(string region);

        /// <summary>
        /// Selects the <see cref="FarmOwner"/> in the given city (Search,Comboboxes)
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        IEnumerable<FarmOwner> GetByCity(string city);

        /// <summary>
        /// Selects the <see cref="FarmOwner"/> in the given PassportNumber (Search,Comboboxes)
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        FarmOwner GetByPassportNumber(string PassportNumber);

        /// <summary>
        /// Selects the <see cref="FarmOwner"/> in the given PhoneNumber (Search,Comboboxes)
        /// </summary>
        /// <param name="region"></param>
        /// <returns></returns>
        FarmOwner GetByPhoneNumber(string PhoneNumber);
    }
}
