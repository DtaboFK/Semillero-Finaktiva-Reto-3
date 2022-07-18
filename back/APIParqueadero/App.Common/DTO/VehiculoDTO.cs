using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Common.DTO
{
    public class VehiculoDTO
    {
        public int IdVehiculo { get; set; }
        public int IdTipoVehiculo { get; set; }
        public string Placa { get; set; }
        public int IdUsuario { get; set; }
        public int IdEstado { get; set; }
    }
}
