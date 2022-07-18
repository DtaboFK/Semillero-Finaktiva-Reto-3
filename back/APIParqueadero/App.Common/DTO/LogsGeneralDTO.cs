using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Common.DTO
{
    public class LogsGeneralDTO
    {
        public int LogID { get; set; }
        public int TypeLog { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public DateTime CreationDate { get; set; }
        public string Messagen { get; set; }

    }
}
