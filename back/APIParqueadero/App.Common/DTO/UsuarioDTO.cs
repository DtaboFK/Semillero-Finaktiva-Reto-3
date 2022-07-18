using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Common.DTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdTipoDoc { get; set; }
        public string Documento { get; set; }
        public string Contacto { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
    }
}
