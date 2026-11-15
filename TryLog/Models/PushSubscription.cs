using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TryLog.Models
{
    public class PushSubscription
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(500)]
        [Index("IX_Endpoint",IsUnique=true)]
        public string Endpoint { get; set; }

        [Required]
        [StringLength(100)]
        public string P256dh { get; set; }

        [Required]
        [StringLength(50)]
        public string Auth { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }
    }
}
