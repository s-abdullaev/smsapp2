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
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int? FarmOwnerId { get; set; }
        public virtual FarmOwner FarmOwner { get; set; }

        public int? PlantId { get; set; }
        public virtual Plant Plant { get; set; }

        public int? DiseaseId { get; set; }
        public virtual Disease Disease { get; set; }

        public int? PestId { get; set; }
        public virtual Pest Pest { get; set; }

        public int? ContagionId { get; set; }
        public virtual Contagion Contagion { get; set; }

        //public Entities Entity { get; set; }
        //public int ItemId { get; set; }

        
    }
}