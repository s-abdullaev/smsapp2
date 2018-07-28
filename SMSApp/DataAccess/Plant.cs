using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSApp.DataAccess
{
    public class Plant:Validation.ValidationModelBase
    {
        public int PlantId { get; set; }
        [Required]
        public string Name { get; set; }
        public string ScientificName { get; set; }
        public string AgriculturalName { get; set; }
        public string VendorCode { get; set; }
        public string IAPTCode { get; set; }
        public string AgriculturalClassification { get; set; }
        public string ScientificClassification { get; set; }
        public string Vendor { get; set; }
        public string CountryOfOrigin { get; set; }
        public string Lifespan { get; set; }
        public string IconUrl { get; set; }
        [Column("AdditionalNotes", TypeName = "ntext")]
        public string AdditionalNotes { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }
    }
}
