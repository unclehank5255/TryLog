using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TryLog.Models
{
    public class UserLogin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(32)]
        [Index("IX_Provider_Key", 1, IsUnique = true)]
        public string Provider { get; set; }

        [Required]
        [StringLength(255)]
        [Index("IX_Provider_Key", 2, IsUnique = true)]
        public string ProviderKey { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }
    }
}
