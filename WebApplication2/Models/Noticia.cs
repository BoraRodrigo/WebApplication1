using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Noticia
    {
        public int ID { get; set; }
        public int Id_topico { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

    }
}