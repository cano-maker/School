using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace School.Web.Models
{
    public class City
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "El campo {0} debe contener al menos un caracter")]
        public string Name { get; set; }

        public ICollection<Neighborhood> Neighborhoods { get; set; }
        public int NeighborhoodsNumber => Neighborhoods == null ? 0 : Neighborhoods.Count;
                
    }
}
