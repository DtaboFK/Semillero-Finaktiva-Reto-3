using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Common.DTO
{
    public class OperarioDTO
    {
        public int IdOperario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdTipoDoc { get; set; }
        public string Documento { get; set; }
        public string Clave { get; set; }
    }
}
