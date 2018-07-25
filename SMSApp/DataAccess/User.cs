using SMSApp.Enums;
using SMSApp.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSApp.DataAccess
{
    public class User:ValidationModelBase
    {
        public User()
        {
            CreatedDate = DateTime.Now;
        }

        public int UserId { get; set; }


        [Required]
        public string Name { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        [StringLength(50,MinimumLength=5)]
        public string Password { get; set; }

        [EmailAddress]
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
