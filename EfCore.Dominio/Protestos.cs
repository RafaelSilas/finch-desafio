using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Dominio
{
    public class Protestos
    {
        [Key] public int idProtesto { get; set; }
        public int Contrato { get; set; }
        public decimal Valor { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime DataEmissao { get; set; }
        public string Operacao { get; set; }
        public string TipoDocumento { get; set; }
    }
}
