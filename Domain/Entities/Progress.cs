using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Progress
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public TimeSpan TotalDuration { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Calories { get; set; }
        [Required]
        public DateTime RecordDate { get; set; }
        [MaxLength(500)]
        public string Comment { get; set; }
        [ForeignKey("PersonId")]
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
