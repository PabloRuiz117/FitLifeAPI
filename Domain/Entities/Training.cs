using Domain.Entities.Relationships;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Training
    {
        [Key]
        public int Id { get; set; }
        public DateTime TrainingStart { get; set; }
        public bool IsCompleted { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

        public ICollection<TrainingRoutines> TrainingRoutines { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}