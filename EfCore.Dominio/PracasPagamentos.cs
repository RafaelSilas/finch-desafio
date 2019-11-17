using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Dominio
{
    public class PracasPagamentos
    {
        [Key] public int idPracaPagamento { get; set; }
        //public  Cidades Cidade { get; set; }
        public int Cidade { get; set; }
        public string Descricao { get; set; }
    }
}
