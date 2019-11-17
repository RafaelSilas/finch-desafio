using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Dominio
{
    public class Usuarios
    {
        [Key] public int idUsuario { get; set; }
        public string login { get; set; }
        public string Senha { get; set; }
    }
}
