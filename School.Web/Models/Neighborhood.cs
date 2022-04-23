using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Web.Models
{
    public class Neighborhood
    {


        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener al menos un caracter")]
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }
        public int StudentsNumber => Students == null ? 0 : Students.Count;

        [NotMapped]
        public int IdCity { get; set; }

    }
}
