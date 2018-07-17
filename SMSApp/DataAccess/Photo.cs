using System;
using SMSApp.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSApp.DataAccess
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public string Title { get; set; }
        [Column("Description", TypeName = "ntext")]
        public string Description { get; set; }
        public string URL { get; set; }
        public DateTime CreatedDate { get; set; }
        //public Entities Entity { get; set; }
        //public int ItemId { get; set; }
    }
}