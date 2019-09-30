using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PosiSIM.Models
{
    public class Formulario
    {
        public string Id_Formulario { get; set; }
        public string Id_Entrevistado { get; set; }
        public string Id_Pesquisador { get; set; }
        public string Data_Hora { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

    }
}