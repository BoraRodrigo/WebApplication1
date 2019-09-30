using PosiSIM.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PosiSIM.Models
{
    public class Resposta
    {
        RespostaDAO RespostaDAO = new RespostaDAO();
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

        public async   System.Threading.Tasks.Task<List<Resposta>> lista_respostaAsync()
        {
            List<Resposta> respostas = new List<Resposta>();
            respostas = await RespostaDAO.Busca_Respostas();
            return respostas;
        }
    }
}