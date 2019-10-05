using Firebase.Database;
using PosiSIM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PosiSIM.DAO
{
    public class Dados_Pesquisa_DAO
    {
        static FirebaseClient firebase = new FirebaseClient("https://integrador-pesquisa.firebaseio.com/");

        static List<Dados_Pesquisa> Lista_dados_Pesquisas = new List<Dados_Pesquisa>();
        //static Dados_Pesquisa dados_Pesquisa = new Dados_Pesquisa();
        static List<Entrevistado> lista_entrevistado = new List<Entrevistado>();

        public async static Task<List<Resposta>> Busca_Respostas()
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
        public async static Task<List<Entrevistado>> Busca_Entrevistado()
        {
            return (await firebase
                .Child("Entrevistado")
                .OnceAsync<Entrevistado>()).Select(item => new Entrevistado
                {
                    Id_Entrevistado = item.Object.Id_Entrevistado,
                    Nome_Completo = item.Object.Nome_Completo,
                    Faixa_Etaria = item.Object.Faixa_Etaria,
                    Genero = item.Object.Genero,
                    Rua = item.Object.Rua,
                    Numero_Casa = item.Object.Numero_Casa
                }).ToList();
        }
        public async static Task<List<Formulario>> Busca_Formulario()
        {
            return (await firebase
                .Child("Formulario")
                .OnceAsync<Formulario>()).Select(item => new Formulario
                {
                    Id_Formulario = item.Object.Id_Formulario,
                    Id_Entrevistado = item.Object.Id_Entrevistado,
                    Id_Pesquisador = item.Object.Id_Pesquisador,
                    Data_Hora = item.Object.Data_Hora,
                    Latitude = item.Object.Latitude,
                    Longitude = item.Object.Longitude,
                }).ToList();
        }

        public async static Task<List<Dados_Pesquisa>> Dados_Pesquisa()
        {
            Lista_dados_Pesquisas.Clear();

            List<Resposta> lista_resposta = new List<Resposta>();

            List<Formulario> lista_Formulario = new List<Formulario>();

            lista_resposta = await Busca_Respostas();
            lista_Formulario = await Busca_Formulario();
            lista_entrevistado = await Busca_Entrevistado();

            for (int p = 0; p < lista_entrevistado.Count; p++)
            {
                Dados_Pesquisa dados_Pesquisa = new Dados_Pesquisa();
                dados_Pesquisa.Id_Entrevistado = lista_entrevistado[p].Id_Entrevistado;
                dados_Pesquisa.Nome_Completo = lista_entrevistado[p].Nome_Completo;
                dados_Pesquisa.Faixa_Etaria = lista_entrevistado[p].Faixa_Etaria;
                dados_Pesquisa.Genero = lista_entrevistado[p].Genero;
                dados_Pesquisa.Rua = lista_entrevistado[p].Rua;
                dados_Pesquisa.Numero_Casa = lista_entrevistado[p].Numero_Casa;

                Lista_dados_Pesquisas.Add(dados_Pesquisa);



                for (int j = 0; j < lista_Formulario.Count; j++)
                {
                    for (int i = 0; i < Lista_dados_Pesquisas.Count; i++)
                    {
                        if (lista_Formulario[j].Id_Entrevistado.Equals(Lista_dados_Pesquisas[i].Id_Entrevistado))
                        {
                            dados_Pesquisa.Id_Formulario_Respondido = lista_Formulario[j].Id_Formulario;
                            dados_Pesquisa.Id_Entrevistado_Respondido = lista_Formulario[j].Id_Entrevistado;
                            dados_Pesquisa.Id_Pesquisador_Respondido = lista_Formulario[j].Id_Pesquisador;
                            dados_Pesquisa.Data_Hora = lista_Formulario[j].Data_Hora;
                            dados_Pesquisa.Latitude = lista_Formulario[j].Latitude;
                            dados_Pesquisa.Longitude = lista_Formulario[j].Longitude;
                        }
                    }
                }
                for (int k = 0; k < lista_resposta.Count; k++)
                {
                    for (int i = 0; i < Lista_dados_Pesquisas.Count; i++)
                    {
                        if (lista_resposta[k].Id_Formulario.Equals(Lista_dados_Pesquisas[i].Id_Entrevistado))
                        {
                            dados_Pesquisa.Id_Formulario = lista_resposta[k].Id_Formulario;
                            dados_Pesquisa.Resposta_1 = lista_resposta[k].Resposta_1;
                            dados_Pesquisa.Resposta_2 = lista_resposta[k].Resposta_2;
                            dados_Pesquisa.Resposta_3 = lista_resposta[k].Resposta_3;
                            dados_Pesquisa.Resposta_3_1 = lista_resposta[k].Resposta_3_1;
                            dados_Pesquisa.Resposta_4 = lista_resposta[k].Resposta_4;
                            dados_Pesquisa.Resposta_4_1 = lista_resposta[k].Resposta_4_1;
                            dados_Pesquisa.Resposta_4_2 = lista_resposta[k].Resposta_4_2;
                            dados_Pesquisa.Resposta_5 = lista_resposta[k].Resposta_5;
                            dados_Pesquisa.Resposta_6 = lista_resposta[k].Resposta_6;
                            dados_Pesquisa.Resposta_7 = lista_resposta[k].Resposta_7;
                            dados_Pesquisa.Resposta_8 = lista_resposta[k].Resposta_8;
                            dados_Pesquisa.Resposta_9 = lista_resposta[k].Resposta_9;
                            dados_Pesquisa.Resposta_9_1 = lista_resposta[k].Resposta_9_1;
                            dados_Pesquisa.Resposta_1_1_1 = lista_resposta[k].Resposta_1_1_1;
                            dados_Pesquisa.Resposta_1_1_2 = lista_resposta[k].Resposta_1_1_2;
                            dados_Pesquisa.Resposta_2_1_0 = lista_resposta[k].Resposta_2_1_0;
                            dados_Pesquisa.Resposta_2_1_1 = lista_resposta[k].Resposta_2_1_1;
                            dados_Pesquisa.Resposta_2_1_2 = lista_resposta[k].Resposta_2_1_2;
                            dados_Pesquisa.Resposta_3_1_0 = lista_resposta[k].Resposta_3_1_0;
                            dados_Pesquisa.Resposta_3_1_1 = lista_resposta[k].Resposta_3_1_1;
                            dados_Pesquisa.Resposta_10 = lista_resposta[k].Resposta_10;
                            dados_Pesquisa.Resposta_11 = lista_resposta[k].Resposta_11;
                        }
                    }

                }
            }
            return Lista_dados_Pesquisas;
        }
    }
}
