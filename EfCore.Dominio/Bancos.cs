using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Dominio
{
    public class Bancos
    {
        [Key] public int idBanco { get; set; }
        public string Nome{ get; set; }
        public int Codigo { get; set; }
        public string CodigoInterno { get; set; }
    }

 
}
