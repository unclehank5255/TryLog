using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TryLog.Models
{
    public class DailyMood
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Index("IX_User_Date", 1, IsUnique = true)]
        public int UserId { get; set; }

        [Column(TypeName = "date")]
        [Index("IX_User_Date", 2, IsUnique = true)]
        public DateTime Date { get; set; }

        [Range(1, 5)]
        public byte Mood { get; set; }

        [ForeignKey("UserId")]
        public virtual AppUser User { get; set; }
    }
}
