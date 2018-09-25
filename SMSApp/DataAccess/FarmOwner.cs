using SMSApp.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        [RegularExpression("^[A-Z]{2}\\d{7}$", ErrorMessage = "Please, input passport number in this format: AA1234567")]
        public string PassportNumber { get; set; }

        public DateTime DateOfBirth { get; set; }= DateTime.Now;
        public bool Gender { get; set; }
        [Required]
        [RegularExpression("^\\+998\\d{9}$", ErrorMessage ="Please, input phone number in this format: +998971234567")]
        public string MobilePhone1 { get; set; }
        [RegularExpression("^\\+998\\d{9}$", ErrorMessage = "Please, input phone number in this format: +998971234567")]
        public string MobilePhone2 { get; set; }
        [Required]
        [RegularExpression("^\\+998\\d{9}$", ErrorMessage = "Please, input phone number in this format: +998971234567")]
        public string HomePhone1 { get; set; }
        [RegularExpression("^\\+998\\d{9}$", ErrorMessage = "Please, input phone number in this format: +998971234567")]
        public string HomePhone2 { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        [Column("AdditionalNotes", TypeName = "ntext")]
        public string AdditionalNotes { get; set; }

        /*FOREIGN KEYS*/
        public int? UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ObservableCollection<Farm> Farms { get; set; } = new ObservableCollection<Farm>();
        public virtual ObservableCollection<Broadcast> Broadcasts { get; set; } = new ObservableCollection<Broadcast>();
        public virtual ObservableCollection<Photo> Photos { get; set; } = new ObservableCollection<Photo>();
        /// <summary>
        /// Interface implementation
        /// </summary>
        [NotMapped]
        public bool IsSelected { get; set; }

    }
}
