using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Common.DTO
{
    public class MensualidadDTO
    {
        public int IdMensualidad { get; set; }
        public int IdCelda { get; set; }
        public DateTime FechaInicio { get; set; }
        public int? FechaFin { get; set; }
        public decimal? ValorPagado { get; set; }
        public int IdUsuario { get; set; }
    }
}
