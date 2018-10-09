using SMSApp.Enums;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSApp.DataAccess
{
    public class Pest:Validation.ValidationModelBase
    {
        public int PestId { get; set; }
        [Required]
        public string Name { get; set; }
        public string ScientificName { get; set; }
        public string AgriculturalName { get; set; }
        public string ScientificClassification { get; set; }
        public string AgriculturalClassification { get; set; }
        [Column("Risks", TypeName = "ntext")]
        public string Risks { get; set; }
        public DangerRating DangerRating { get; set; }
        public string SpeedOfGrowth { get; set; }
        [Column("Prevention", TypeName = "ntext")]
        public string Prevention { get; set; }
        [Column("Detection", TypeName = "ntext")]
        public string Detection { get; set; }
        [Column("ChemicalTreatment", TypeName = "ntext")]
        public string ChemicalTreatment { get; set; }
        [Column("NonChemicalTreatment", TypeName = "ntext")]
        public string NonChemicalTreatment { get; set; }
        [Column("Prognosis", TypeName = "ntext")]
        public string Prognosis { get; set; }
        public string Lifespan { get; set; }
        [Column("AdditionalNotes", TypeName = "ntext")]
        public string AdditionalNotes { get; set; }

        public virtual ObservableCollection<Contagion> Contagions { get; set; }
        public virtual ObservableCollection<Photo> Photos { get; set; } = new ObservableCollection<Photo>();
    }
}
