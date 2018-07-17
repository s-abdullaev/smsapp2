using SMSApp.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMSApp.DataAccess
{
    public class Message
    {
        public int MessageId { get; set; }
        public MessageStatuses Status { get; set; }
        [Column("Feedback", TypeName = "ntext")]
        public string Feedback { get; set; }
        public DateTime Date { get; set; }

        /*FOREIGN KEYS*/
        [Index("IX_UniqueMessage", 1, IsUnique = true)]
        public int? BroadcastId { get; set; }
        public virtual Broadcast Broadcast { get; set; }

        [Index("IX_UniqueMessage", 2, IsUnique = true)]
        public int FarmOwnerId { get; set; }
        public FarmOwner FarmOwner { get; set; }
    }
}
