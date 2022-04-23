using System.ComponentModel.DataAnnotations;

namespace School.Web.Models
{
    public class Student
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener al menos un caracter")]
        public string Name { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener al menos un caracter")]
        public string LastName { get; set; }
        [Required]
        public int Document { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "El campo {0} debe contener al menos un caracter")]
        public string NumberPhone { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "El campo {0} debe contener al menos un caracter")]
        public string Email { get; set; }
        [Required]
        public int Level { get; set; }
        [Required]
        public string Age { get; set; }
    }
}
