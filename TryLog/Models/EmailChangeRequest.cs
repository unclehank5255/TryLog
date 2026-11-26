using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TryLog.Models
{
    public class EmailChangeRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(254)]
        public string OldEmail { get; set; }

        [Required]
        [StringLength(254)]
        [EmailAddress(ErrorMessage = "信箱格式不正確")]
        public string NewEmail { get; set; }

        [Required]
        [StringLength(64)]
        [Index]
        public string TokenHash { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime TokenExpiresAt { get; set; }

        public EmailChangeStatus Status { get; set; }

        [StringLength(64)]
        [Index]
        public string RevertTokenHash { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? RevertExpiresAt { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedAt { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? CompletedAt { get; set; }

        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }
    }
}
