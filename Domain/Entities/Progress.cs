using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Progress
    {
        [Key]
        public int Id { get; set; }
        public TimeSpan Duration { get; set; }
        public int Calories { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
