using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Database.Entities
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public int IdTipoDoc { get; set; }
        [Required]
        public string Documento { get; set; }
        [Required]
        public string Contacto { get; set; }
        [Required]
        public string Correo { get; set; }
        [Required]
        public string Direccion { get; set; }
    }
}
