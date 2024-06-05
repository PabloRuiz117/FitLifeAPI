using System.ComponentModel.DataAnnotations;

namespace Common.Enums
{
    public class Enumerations
    {
        public enum Gender
        {
            [Display(Name = "Masculino")]
            MALE,
            [Display(Name = "Femenino")]
            FEMALE
        }

        public enum DayOfWeek
        {
            [Display(Name = "Domingo")]
            SUNDAY,
            [Display(Name = "Lunes")]
            MONDAY,
            [Display(Name = "Martes")]
            TUESDAY,
            [Display(Name = "Miercoles")]
            WEDNESDAY,
            [Display(Name = "Jueves")]
            THURSDAY,
            [Display(Name = "Viernes")]
            FRIDAY,
            [Display(Name = "Sabado")]
            SATURDAY,
        }
    }
}
