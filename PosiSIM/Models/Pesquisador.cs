using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PosiSIM.Models
{
    public class Pesquisador
    {
        public string Id_Pesquisador { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public string Data_Nascimento { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}