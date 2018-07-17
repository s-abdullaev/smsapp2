using SMSApp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSApp.DataAccess
{
    public class User
    {
        public User()
        {
            CreatedDate = DateTime.Now;
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserPermissions Permissions { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Farm> Farms { get; set; }
        public virtual ICollection<FarmOwner> FarmOwners { get; set; }
        public virtual ICollection<SoilReading> SoilReadings { get; set; }
        public virtual ICollection<Contagion> Contagions { get; set; }
        public virtual ICollection<Broadcast> Broadcasts { get; set; }
    }
}
