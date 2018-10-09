namespace SMSApp.Migrations
{
    using SMSApp.DataAccess;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SMSApp.DataAccess.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SMSApp.DataAccess.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            IList<FarmOwner> farmOwners = new List<FarmOwner>
            {

                new FarmOwner { LastName = "Lastname1", FirstName = "FirstName1", PassportNumber = "AA0112233", DateOfBirth = DateTime.Parse("2011-03-21"), Gender = true, MobilePhone1 = "+998971234567", HomePhone1="+998971234567", Email = "farmer1@mail.com", Address = "Address1", City = "Tashkent", Region = "Region" },
                new FarmOwner { LastName = "Lastname2", FirstName = "FirstName2", PassportNumber = "AA0112234", DateOfBirth = DateTime.Parse("2010-03-21"), Gender = false, MobilePhone1 = "+998971234568", HomePhone1="+998971234561", Email = "farmer2@mail.com", Address = "Address2", City = "Tashkent", Region = "Region" },
                new FarmOwner { LastName = "Lastname3", FirstName = "FirstName3", PassportNumber = "AA0112235", DateOfBirth = DateTime.Parse("2012-03-21"), Gender = true, MobilePhone1 = "+998971234569", HomePhone1="+998971234562", Email = "farmer3@mail.com", Address = "Address3", City = "Tashkent", Region = "Region" }

            };

            //IList<Farm> farms = new List<Farm>
            //{
            //    new Farm { Name = "Farm1", Address = "Address1", City = "City1", Region = "Region1", RegistrationCertificateNum = "001", EstablishedYear = DateTime.Parse("2008-01-21"), Area = 54.5f, IndustryType = "Type1", /*FarmOwner = farmOwners[0], User = users[0]*/ },
            //    new Farm { Name = "Farm2", Address = "Address2", City = "City2", Region = "Region2", RegistrationCertificateNum = "002", EstablishedYear = DateTime.Parse("2008-02-21"), Area = 54.5f, IndustryType = "Type2", /*FarmOwner = farmOwners[1], User = users[1]*/ },
            //    new Farm { Name = "Farm3", Address = "Address3", City = "City3", Region = "Region3", RegistrationCertificateNum = "003", EstablishedYear = DateTime.Parse("2008-03-21"), Area = 54.5f, IndustryType = "Type3", /*FarmOwner = farmOwners[2], User = users[2]*/ }
            //};

            
            context.FarmOwners.AddRange(farmOwners);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
