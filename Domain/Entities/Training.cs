using Common.Enums;
using Domain.Entities.Relationships;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Training
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime TrainingStart { get; set; }
        public bool IsCompleted { get; set; }
        [Required]
        public Enumerations.DayOfWeek DayOfWeek { get; set; }

        public ICollection<TrainingRoutines> TrainingRoutines { get; set; }

        [ForeignKey("PersonId")]
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}