using EF6CodeFirstDemo.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSApp.DataAccess
{
    public class Broadcast
    {
        public int BroadcastId { get; set; }
        [Column("MessageText", TypeName = "ntext")]
        public string MessageText { get; set; }
        public BroadcastWarningLevels WarningLevel { get; set; }
        public DateTime Date { get; set; }

        /*FOREIGN KEYS*/
        public int? ContagionId { get; set; }
        public virtual Contagion Contagion { get; set; }
        
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
