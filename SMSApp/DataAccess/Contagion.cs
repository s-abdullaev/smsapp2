using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSApp.DataAccess
{
    public class Contagion :Validation.ValidationModelBase
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
        public virtual Season FarmPlant { get; set; }
        
        //public int? UserId { get; set; }
        //public virtual User User { get; set; }

        public virtual ObservableCollection<Disease> Diseases { get; set; } = new ObservableCollection<Disease>();
        public virtual ObservableCollection<Pest> Pests { get; set; } = new ObservableCollection<Pest>();
        public virtual ObservableCollection<Broadcast> Broadcasts { get; set; } = new ObservableCollection<Broadcast>();
        public virtual ObservableCollection<Photo> Photos { get; set; } = new ObservableCollection<Photo>();
    }
}
