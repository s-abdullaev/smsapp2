using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSApp.DataAccess
{
    public class Contagion
    {
        public int ContagionId { get; set; }
        public float DamageInMoney { get; set; }
        public float DamageInCropVolume { get; set; }
        public float DamageInPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [Column("AdditionalNotes", TypeName = "ntext")]
        public string AdditionalNotes { get; set; }

        /*FOREIGN KEYS*/
        public int? FarmPlantId { get; set; }
        public virtual FarmPlant FarmPlant { get; set; }
        
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Disease> Diseases { get; set; }
        public virtual ICollection<Pest> Pests { get; set; }
        public virtual ICollection<Broadcast> Broadcasts { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
