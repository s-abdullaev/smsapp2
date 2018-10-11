using SMSApp.Enums;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SMSApp.DataAccess
{
    public class Season:Validation.ValidationModelBase
    {
        public int SeasonId { get; set; }
        [Index("IX_UniqueFarmPlant", 2, IsUnique = true)]
        public int Year { get; set; }
        [Index("IX_UniqueFarmPlant", 3, IsUnique = true)]
        public SeasonTimes SeasonTime { get; set; }
        public PlantGrowthStatus GrowthStatus { get; set; }
        public double ExpectedYield { get; set; }
        public double InitialInvestment { get; set; }
        [Column("AdditionalNotes", TypeName = "ntext")]
        public string AdditionalNotes { get; set; }

        /*FOREIGN KEYS*/
        [Index("IX_UniqueFarmPlant", 1, IsUnique = true)]
        public int? GeopositionId { get; set; }
        public Geoposition Geoposition { get; set; }

        //[Index("IX_UniqueFarmPlant", 2, IsUnique = true)]
        //public int? PlantId { get; set; }
        //public Plant Plant { get; set; }

        public virtual ObservableCollection<Contagion> Contagions { get; set; } = new ObservableCollection<Contagion>();
        public virtual ObservableCollection<SeasonPlant> Plants { get; set; } = new ObservableCollection<SeasonPlant>();

        [NotMapped]
        public string PlantNames { get {

                return string.Join(",",(from sp in Plants select sp.Plant.Name));
            }}
    }
}
