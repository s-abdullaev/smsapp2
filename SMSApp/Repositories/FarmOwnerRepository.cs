using SMSApp.DataAccess;
using SMSApp.Repositories.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SMSApp.Repositories
{
    public class FarmOwnerRepository : Repository<FarmOwner>, IFarmOwnerRepository
    {
        public FarmOwnerRepository(Context dbContext)
            : base(dbContext)
        {

        }

        public IEnumerable<FarmOwner> GetByCity(string city)
        {
            return mContext.Set<FarmOwner>().Where(a => a.City == city).ToList();
        }

        public FarmOwner GetByPassportNumber(string PassportNumber)
        {
            return mContext.Set<FarmOwner>().Where(a => a.PassportNumber == PassportNumber).FirstOrDefault();
        }

        public FarmOwner GetByPhoneNumber(string PhoneNumber)
        {
            return mContext.Set<FarmOwner>().Where(a =>
            (a.MobilePhone1 == PhoneNumber)|| (a.MobilePhone2 == PhoneNumber) || (a.HomePhone1 == PhoneNumber) || (a.HomePhone2 == PhoneNumber) 
            ).FirstOrDefault();
        }
        
    }
}
