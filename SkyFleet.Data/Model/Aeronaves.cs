using System.ComponentModel.DataAnnotations;

namespace SkyFleet.Data.Model;
    class Aeronaves
    {

        [Key]
        public int AeronaveId { get; set; }

        public int estadoId { get; set; }

        [Required(ErrorMessage = "El modelo es obligatorio")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El campo solo puede contener letras y espacios.")]
        public string? ModeloAvion { get; set; }

        [Required(ErrorMessage = "La descripcion de la categoria es obligatoria")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El campo solo puede contener letras y espacios.")]
        public string? DescripcionCategoria { get; set; }

        [Required(ErrorMessage = "La Registracion es obligatoria")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El campo solo puede contener letras y espacios.")]
        public string? Registracion { get; set; }

        public double? CostoXHora { get; set; }

        [Required(ErrorMessage = "La descripcion de la Aeronave es obligatoria")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El campo solo puede contener letras y espacios.")]
        public string? DescripcionAeronave { get; set; }

        public double? VelocidadMaxima { get; set; }

        [Required(ErrorMessage = "La descripcion del motor es obligatoria")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El campo solo puede contener letras y espacios.")]
        public string? DescripcionMotor { get; set; }

        public int? CapacidadCombustible { get; set; }

        public int? ConsumoXHora { get; set; }
        public double? Peso { get; set; }
        public int? Rango { get; set; }
        public int? CapacidadPasajeros { get; set; }
        public int? AltitudMaxima { get; set; }

        [Required(ErrorMessage = "La Licencia es Obligatoria")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El campo solo puede contener letras y espacios.")]
        public string? Licencia { get; set; }




}
