using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PosiSIM.Models
{
    public class Dados_Pesquisa
    {
        //Dados das Respostas
        public string Id_Formulario { get; set; }
        public string Resposta_1 { get; set; } = "";
        public string Resposta_2 { get; set; } = "";
        public string Resposta_3 { get; set; } = "";
        public string Resposta_3_1 { get; set; } = "";
        public string Resposta_4 { get; set; } = "";
        public string Resposta_4_1 { get; set; } = "";
        public string Resposta_4_2 { get; set; } = "";
        public string Resposta_5 { get; set; } = "";
        public string Resposta_6 { get; set; } = "";
        public string Resposta_7 { get; set; } = "";
        public string Resposta_8 { get; set; } = "";
        public string Resposta_9 { get; set; } = "";
        public string Resposta_9_1 { get; set; } = "";
        public string Resposta_1_1_1 { get; set; } = "";
        public string Resposta_1_1_2 { get; set; } = "";
        public string Resposta_2_1_0 { get; set; } = "";
        public string Resposta_2_1_1 { get; set; } = "";
        public string Resposta_2_1_2 { get; set; } = "";
        public string Resposta_3_1_0 { get; set; } = "";
        public string Resposta_3_1_1 { get; set; } = "";
        public string Resposta_10 { get; set; } = "";
        public string Resposta_11 { get; set; } = "";


        //Dados do entrevistado
        public string Id_Entrevistado { get; set; }
        public string Nome_Completo { get; set; }
        public string Faixa_Etaria { get; set; }
        public string Genero { get; set; }
        public string Rua { get; set; }
        public string Numero_Casa { get; set; }


        //Dados do formulario
        public string Id_Formulario_Respondido { get; set; }
        public string Id_Entrevistado_Respondido { get; set; }
        public string Id_Pesquisador_Respondido { get; set; }
        public string Data_Hora { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}