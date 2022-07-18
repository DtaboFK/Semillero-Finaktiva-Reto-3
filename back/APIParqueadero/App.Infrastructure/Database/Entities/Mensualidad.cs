using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Database.Entities
{
    public class Mensualidad
    {
        [Key]
        public int IdMensualidad { get; set; }
        [Required]
        public int IdCelda { get; set; }
        [Required]
        public DateTime FechaInicio { get; set; }
        public int? FechaFin { get; set; }
        public decimal? ValorPagado { get; set; }
        [Required]
        public int IdUsuario { get; set; }
    }
}
