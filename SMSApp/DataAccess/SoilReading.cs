using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSApp.DataAccess
{
    public class SoilReading
    {
        public int SoilReadingId { get; set; }
        public float HumusLevel { get; set; }
        public float PottasiumLevel { get; set; }
        public float PhosphorusLevel { get; set; }
        public float NitrateLevel { get; set; }
        public float AcidityLevel { get; set; }
        public float SoilFertilityRating { get; set; }
        public DateTime Date { get; set; }
        [Column("AdditionalNotes", TypeName = "ntext")]
        public string AdditionalNotes { get; set; }

        /*FOREIGN KEYS*/
        public int? GeopositionId { get; set; }
        public virtual Geoposition Geoposition { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
