using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Dominio
{
    public class ContratosParcelas
    {
        [Key] public int idContratoParcela { get; set; }
        public int Contrato { get; set; }
        public int Parcela { get; set; }
    }
}
