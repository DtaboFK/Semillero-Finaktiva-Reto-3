using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Infrastructure.Database.Entities
{
    public class LogsGeneral
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogID { get; set; }
        public int TypeLog { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public DateTime CreationDate { get; set; }
        public string Messagen { get; set; }

    }
}
