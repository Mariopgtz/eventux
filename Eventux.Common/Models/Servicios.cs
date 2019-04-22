using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventux.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Servicios
    {
        [Key]

        public int ServiceId { get; set; }

        [Required]

        [Display(Name = "Imagen")]
        public string ImagePath { get; set; }


        public string Servicio { get; set; }
        
        public string Encargado { get; set; }

        [Display(Name = "Descripción")]
        [DataType(DataType.MultilineText)]
        [StringLength(100)]
        public string Description { get; set; }

        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Display(Name = "Teléfono")]
        [StringLength(10)]
        public string Telefono { get; set; }

        [Display(Name = "Fecha de publicación")]
        [DataType(DataType.Date)]
        public DateTime PublishOn { get; set; }

        public override string ToString()
        {
            return this.Servicio;
        }
    }
}
