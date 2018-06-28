using EF6CodeFirstDemo.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSApp.DataAccess
{
    public class FarmPlant
    {
        public int FarmPlantId { get; set; }
        [Index("IX_UniqueFarmPlant", 3, IsUnique = true)]
        public int Year { get; set; }
        [Index("IX_UniqueFarmPlant", 4, IsUnique = true)]
        public Seasons Season { get; set; }
        public PlantGrowthStatus GrowthStatus { get; set; }
        public double ExpectedYield { get; set; }
        public double InitialInvestment { get; set; }
        [Column("AdditionalNotes", TypeName = "ntext")]
        public string AdditionalNotes { get; set; }

        /*FOREIGN KEYS*/
        [Index("IX_UniqueFarmPlant", 1, IsUnique = true)]
        public int? GeopositionId { get; set; }
        public Geoposition Geoposition { get; set; }

        [Index("IX_UniqueFarmPlant", 2, IsUnique = true)]
        public int? PlantId { get; set; }
        public Plant Plant { get; set; }

        public virtual ICollection<Contagion> Contagions { get; set; }
    }
}
