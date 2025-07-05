using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFleet.Data.Model
{
    public class Rutas
    {
        [Key]
        public int RutaId { get; set; }

        [Required(ErrorMessage = "Campo nombre obligatorio")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El campo solo puede contener letras y espacios.")]
        public string? origen { get; set; }

        [Required(ErrorMessage = "Campo nombre obligatorio")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El campo solo puede contener letras y espacios.")]
        public string? destino { get; set; }

        public decimal? distancia { get; set; }

        public int? duracion { get; set; }


    }
}
