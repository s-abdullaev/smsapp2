using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSApp.DataAccess
{
    public class Farm:Validation.ValidationModelBase
    {
        public int FarmId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string RegistrationCertificateNum { get; set; }
        public DateTime EstablishedYear { get; set; }
        public float Area { get; set; }
        public string IndustryType { get; set; }
        [Column("AdditionalNotes", TypeName = "ntext")]
        public string AdditionalNotes { get; set; }
        public string LogoUrl { get; set; }

        /*FOREIGN KEYS*/
        public int? UserId { get; set; }
        public virtual User User { get; set; }

        public int? FarmOwnerId { get; set; }
        public virtual FarmOwner FarmOwner { get; set; }

        public virtual ICollection<Geoposition> Geopositions { get; set; }
    }
}
