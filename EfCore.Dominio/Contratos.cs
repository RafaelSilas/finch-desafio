using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Dominio
{
    public class Contratos
    {
        [Key] public int idContrato { get; set; }
        public int PracaPagamento { get; set; }
        public int Devedor { get; set; }
        public int Banco { get; set; }
        public string Numero { get; set; }
        public decimal ValorPrimeiraParcela { get; set; }
        public decimal Valor{ get; set; }
        public int QtdParcelas { get; set; }
    }
}
