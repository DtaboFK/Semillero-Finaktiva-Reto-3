using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Database.Entities
{
    public class Vehiculo
    {
        [Key]
        public int IdVehiculo { get; set; }
        [Required]
        public int IdTipoVehiculo { get; set; }
        [Required]
        public string Placa { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public bool IdEstado { get; set; }
    }
}
