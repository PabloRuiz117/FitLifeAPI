using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Relationships
{
    public class TrainingRoutines
    {
        [ForeignKey("TrainingId")]
        public int TrainingId { get; set; }
        public Training Training { get; set; }

        [ForeignKey("RoutineId")]
        public int RoutineId { get; set; }
        public Routine Routine { get; set; }
    }
}
