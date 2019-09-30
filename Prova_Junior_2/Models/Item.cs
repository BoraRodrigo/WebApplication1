using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prova_Junior_2.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int Id_Pessoa { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public string Quantidade { get; set; }
    }
}