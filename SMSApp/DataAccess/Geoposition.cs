using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSApp.DataAccess
{
    public class Geoposition
    {
        public int GeopositionId { get; set; }
        public string Name { get; set; }
        [Column("GeoData", TypeName = "ntext")]
        public string GeoData { get; set; }
        public float Area { get; set; }
        [Column("AdditionalNotes", TypeName = "ntext")]
        public string AdditionalNotes { get; set; }

        /*FOREIGN KEYS*/
        public int FarmId { get; set; }
        public virtual Farm Farm { get; set; }

        public virtual ICollection<SoilReading> SoilReadings { get; set; }
    }
}
