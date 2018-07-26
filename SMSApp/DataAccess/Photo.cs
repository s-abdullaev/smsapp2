using System;
using SMSApp.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SMSApp.DataAccess
{
    public class Photo:Validation.ValidationModelBase
    {
        public int PhotoId { get; set; }
        public string Title { get; set; }
        [Column("Description", TypeName = "ntext")]
        public string Description { get; set; }
        [Required]
        public string URL { get; set; }
        public DateTime CreatedDate { get; set; }
        //public Entities Entity { get; set; }
        //public int ItemId { get; set; }
    }
}