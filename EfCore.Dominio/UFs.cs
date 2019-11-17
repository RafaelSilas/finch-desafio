using EFCore.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Dominio
{
    public class UFs
    {
       [Key] public int idUf { get; set; }
        public string Descricao { get; set; }
    }
}
