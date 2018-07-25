using SMSApp.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSApp.DataAccess
{
    public class FarmOwner : Validation.ValidationModelBase, ISelectable
    {
        public int FarmOwnerId { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string PassportNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public char Gender { get; set; }
        [Required]
        public string MobilePhone1 { get; set; }
        public string MobilePhone2 { get; set; }
        [Required]
        public string HomePhone1 { get; set; }
        public string HomePhone2 { get; set; }
        [Required]
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        [Column("AdditionalNotes", TypeName = "ntext")]
        public string AdditionalNotes { get; set; }

        /*FOREIGN KEYS*/
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Farm> Farms { get; set; }
        public virtual ICollection<Broadcast> Broadcasts { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        /// <summary>
        /// Interface implementation
        /// </summary>
        [NotMapped]
        public bool IsSelected { get; set; }
    }
}
