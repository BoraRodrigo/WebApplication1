using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PosiSIM.Models
{
    public class Entrevistado
    {
        public string Id_Entrevistado { get; set; }
        public string Nome_Completo { get; set; }
        public string Faixa_Etaria { get; set; }
        public string Genero { get; set; }
        public string Rua { get; set; }
        public string Numero_Casa { get; set; }
    }
}