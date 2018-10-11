using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSApp.DataAccess
{
    public class SeasonPlant:Validation.ValidationModelBase
    {
        public int SeasonPlantId { get; set; }
        public int? SeasonId { get; set; }
        public int? PlantId { get; set; }

        public virtual Season Season { get; set;}
        public virtual Plant Plant { get; set; }

    }
}
