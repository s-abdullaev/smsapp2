namespace SMSApp.Migrations
{
    using System;
    using SMSApp.DataAccess;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            IList<User> users = new List<User>
            {
                new User { Name = "User 1", Login = "user_1", Password = "password", Email = "user1@mail.com", Permissions = 0, CreatedDate = DateTime.Now },
                new User { Name = "User 2", Login = "user_2", Password = "password", Email = "user2@mail.com", Permissions = 0, CreatedDate = DateTime.Now },
                new User { Name = "User 3", Login = "user_3", Password = "password", Email = "user3@mail.com", Permissions = 0, CreatedDate = DateTime.Now },
            };

            IList<FarmOwner> farmOwners = new List<FarmOwner>
            {
                new FarmOwner { LastName = "Lastname1", FirstName = "FirstName1", PassportNumber = "AA0112233", DateOfBirth = DateTime.Parse("2011-03-21"), Gender = 'M', MobilePhone1 = "+998971234567", Email = "farmer1@mail.com", Address = "Address1", City = "Tashkent", Region = "Region", User = users[0] },
                new FarmOwner { LastName = "Lastname2", FirstName = "FirstName2", PassportNumber = "AA0112234", DateOfBirth = DateTime.Parse("2010-03-21"), Gender = 'F', MobilePhone1 = "+998971234568", Email = "farmer2@mail.com", Address = "Address2", City = "Tashkent", Region = "Region", User = users[1] },
                new FarmOwner { LastName = "Lastname3", FirstName = "FirstName3", PassportNumber = "AA0112235", DateOfBirth = DateTime.Parse("2012-03-21"), Gender = 'M', MobilePhone1 = "+998971234569", Email = "farmer3@mail.com", Address = "Address3", City = "Tashkent", Region = "Region", User = users[2] }
            };

            IList<Farm> farms = new List<Farm>
            {
                new Farm { Name = "Farm1", Address = "Address1", City = "City1", Region = "Region1", RegistrationCertificateNum = "001", EstablishedYear = DateTime.Parse("2008-01-21"), Area = 54.5f, IndustryType = "Type1", /*FarmOwner = farmOwners[0], User = users[0]*/ },
                new Farm { Name = "Farm2", Address = "Address2", City = "City2", Region = "Region2", RegistrationCertificateNum = "002", EstablishedYear = DateTime.Parse("2008-02-21"), Area = 54.5f, IndustryType = "Type2", /*FarmOwner = farmOwners[1], User = users[1]*/ },
                new Farm { Name = "Farm3", Address = "Address3", City = "City3", Region = "Region3", RegistrationCertificateNum = "003", EstablishedYear = DateTime.Parse("2008-03-21"), Area = 54.5f, IndustryType = "Type3", /*FarmOwner = farmOwners[2], User = users[2]*/ }
            };

            context.Users.AddRange(users);
            context.FarmOwners.AddRange(farmOwners);

            base.Seed(context);
        }
    }
}
