using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFleet.Domain.DTO
{
    public class AeronaveDTO
    {
        public int AeronaveId { get; set; }
        public int estadoId { get; set; }
        public string? ModeloAvion { get; set; }
        public string? DescripcionCategoria { get; set; }
        public string? Registracion { get; set; }
        public double? CostoXHora { get; set; }
        public string? DescripcionAeronave { get; set; }
        public double? VelocidadMaxima { get; set; }
        public string? DescripcionMotor { get; set; }
        public int? CapacidadCombustible { get; set; }
        public int? ConsumoXHora { get; set; }
        public double? Peso { get; set; }
        public int? Rango { get; set; }
        public int? CapacidadPasajeros { get; set; }
        public int? AltitudMaxima { get; set; }
        public string? Licencia { get; set; }
    }
}
