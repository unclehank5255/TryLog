using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TryLog.Models
{
    [Table("Users")]
    public class AppUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string UserName { get; set; }

        [Required]
        [StringLength(254)]
        [EmailAddress(ErrorMessage = "信箱格式不正確")]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [StringLength(128)]
        public string PasswordHash { get; set; }

        [Required]
        [StringLength(64)]
        public string TimeZone { get; set; }

        [StringLength(64)]
        public string PendingTimeZone { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TimeZoneEffectiveDate { get; set; }

        [Range(0, 8)]
        public byte AvatarColor { get; set; }

        public bool IsEmailVerified { get; set; }

        [StringLength(64)]
        public string EmailVerificationTokenHash { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? EmailVerificationTokenExpiresAt { get; set; }

        [StringLength(64)]
        public string PasswordResetTokenHash { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? PasswordResetTokenExpiresAt { get; set; }

        public UserRole Role { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? BannedAt { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? MarkedAt { get; set; }

        [Required]
        [StringLength(64)]
        public string SecurityStamp { get; set; }

        public GoalSortMode SortMode { get; set; }

        public ThemeName Theme { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<UserLogin> Logins { get; set; }
        public virtual ICollection<Goal> Goals { get; set; }
        public virtual ICollection<DailyMood> Moods { get; set; }
        public virtual ICollection<PushSubscription> PushSubscriptions { get; set; }
        public virtual ICollection<EmailChangeRequest> EmailChangeRequests { get; set; }
    }
}
