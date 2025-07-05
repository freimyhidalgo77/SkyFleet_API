using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyFleet.Domain.DTO
{
    public class RutaDTO
    {
        public int RutaId { get; set; }

        public string? origen { get; set; }

        public string? destino { get; set; }

        public decimal? distancia { get; set; }

        public int? duracion { get; set; }


    }
}
