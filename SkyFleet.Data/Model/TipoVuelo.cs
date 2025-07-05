using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFleet.Data.Model
{
    public class TipoVuelo
    {
        [Key]
        public int tipoVueloId { get; set; }

        [Required(ErrorMessage = "Campo nombre obligatorio")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El campo solo puede contener letras y espacios.")]
        public string? nombreVuelo { get; set; }

        public string? descripcionTipoVuelo { get; set; }


    }
}
