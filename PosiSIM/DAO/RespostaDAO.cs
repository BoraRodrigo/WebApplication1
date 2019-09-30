using Firebase.Database;
using PosiSIM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PosiSIM.DAO
{
    public class RespostaDAO
    {
       static  FirebaseClient firebase = new FirebaseClient("https://integrador-pesquisa.firebaseio.com/");

        public async static  Task<List<Resposta>> Busca_Respostas()
        {
            return (await firebase
                .Child("Resposta")
                .OnceAsync<Resposta>()).Select(item => new Resposta
                {
                    Id_Formulario = item.Object.Id_Formulario,
                    Resposta_1 = item.Object.Resposta_1,
                    Resposta_2 = item.Object.Resposta_2,
                    Resposta_3 = item.Object.Resposta_3,
                    Resposta_3_1 = item.Object.Resposta_3_1,
                    Resposta_4 = item.Object.Resposta_4,
                    Resposta_4_1 = item.Object.Resposta_4_1,
                    Resposta_4_2 = item.Object.Resposta_4_2,
                    Resposta_5 = item.Object.Resposta_5,
                    Resposta_6 = item.Object.Resposta_6,
                    Resposta_7 = item.Object.Resposta_7,
                    Resposta_8 = item.Object.Resposta_8,
                    Resposta_9 = item.Object.Resposta_9,
                    Resposta_10 = item.Object.Resposta_10,
                    Resposta_11 = item.Object.Resposta_11,
                    Resposta_9_1 = item.Object.Resposta_9_1,
                    Resposta_1_1_1 = item.Object.Resposta_1_1_1,
                    Resposta_1_1_2 = item.Object.Resposta_1_1_2,
                    Resposta_2_1_0 = item.Object.Resposta_2_1_0,
                    Resposta_2_1_1 = item.Object.Resposta_2_1_1,
                    Resposta_2_1_2 = item.Object.Resposta_2_1_2,
                    Resposta_3_1_0 = item.Object.Resposta_3_1_0,
                    Resposta_3_1_1 = item.Object.Resposta_3_1_1,

                }).ToList();

        }
    }
}
