using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Dominio
{
    public class Devedores
    {
       [Key] public int idDevedor { get; set; }
        public string Nome { get; set; }
        public string CPF_CNPJ { get; set; }
    }
}
