using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Dominio
{
    public class DevedoresEnderecos
    {
        [Key] public int idDevedorEndereco { get; set; }
        //public Cidades Cidade { get; set; }
        //public Devedores Devedor { get; set; }
        public int Devedor { get; set; }
        public int Cidade { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
    }
}
