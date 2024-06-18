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
            [Display(Name = "Miércoles")]
            WEDNESDAY,
            [Display(Name = "Jueves")]
            THURSDAY,
            [Display(Name = "Viernes")]
            FRIDAY,
            [Display(Name = "Sabado")]
            SATURDAY,
        }

        public enum TypeMessage
        {
            [Display(Name = "Éxito")]
            SUCCESS,
            [Display(Name = "Advertencia")]
            WARNING,
            [Display(Name = "Ha ocurrido un error")]
            ERROR,
        }

        public enum DietType
        {
            [Display(Name = "Keto")]
            Keto,
            [Display(Name = "Vegetariano")]
            Vegetarian,
            [Display(Name = "Vegano")]
            Vegan,
            [Display(Name = "Paleo")]
            Paleo,
            [Display(Name = "Otro")]
            Other
        }
    }
}
