using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Prova_Junior.Models
{
    public class Noticia
    {
        public int Id_Noticia { get; set; }

    
        public string Nome { get; set; }
        public string Tipo { get; set; }

        public string Descricao { get; set; }

        public void Cadastrar_Noticia(Noticia noticia)

        {
            SqlConnection conec = new SqlConnection("Data Source=.;Initial Catalog=Mvc_Junior;Integrated Security=True");
            SqlCommand comando = new SqlCommand("INSERT INTO Noticia VALUES('" + noticia.Nome + "','" + noticia.Tipo + "','" + noticia.Descricao + "')", conec);
            conec.Open();
            comando.ExecuteNonQuery();//salva e não retorna nennhum valor.
            conec.Close();
        }
        public static List<Noticia> Lista_Noticia()
        {
            List<Noticia> Lista_Noticia = new List<Noticia>();
            SqlConnection conec = new SqlConnection("Data Source=.;Initial Catalog=Mvc_Junior;Integrated Security=True");
            SqlCommand comando = new SqlCommand("SELECT * FROM Noticia", conec);
            conec.Open();

            Noticia noticia = new Noticia();
            SqlDataReader dr = comando.ExecuteReader();
            while (dr.Read())
            {
                Lista_Noticia.Add(new Noticia()
                {
                    Id_Noticia = Convert.ToInt32(dr["Id_Noticia"]),
                    Nome = dr["Nome"].ToString(),
                    Tipo = dr["Tipo"].ToString(),
                    Descricao =dr["Descricao"].ToString(),                  
                });
            }

            dr.Close();
            return Lista_Noticia;
        }
        public  List<Noticia> Lista_NoticiaID(int id)
        {
            List<Noticia> Lista_Noticia = new List<Noticia>();
            SqlConnection conec = new SqlConnection("Data Source=.;Initial Catalog=Mvc_Junior;Integrated Security=True");
            SqlCommand comando = new SqlCommand("SELECT * FROM  Noticia  where Id_Noticia =" + id + ";", conec);
            conec.Open();

            Noticia noticia = new Noticia();
            SqlDataReader dr = comando.ExecuteReader();
            while (dr.Read())
            {
                Lista_Noticia.Add(new Noticia()
                {
                    Id_Noticia = Convert.ToInt32(dr["Id_Noticia"]),
                    Nome = dr["Nome"].ToString(),
                    Tipo = dr["Tipo"].ToString(),
                    Descricao = dr["Descricao"].ToString(),
                });
            }

            dr.Close();
            return Lista_Noticia;
        }
        public void Alterar_Noticia(Noticia noticia)
        {
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=Mvc_Junior;Integrated Security=True");
            SqlCommand comando = new SqlCommand("UPDATE Noticia SET Nome='" + noticia.Nome + "', Tipo='" + noticia.Tipo + "', Descricao='" + noticia.Descricao  + "' WHERE Id_Noticia = " + noticia.Id_Noticia + "; ", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }
        public void Excluir(Noticia noticia)
        {
            SqlConnection conec = new SqlConnection("Data Source=.;Initial Catalog=Mvc_Junior;Integrated Security=True");
            SqlCommand comando = new SqlCommand("DELETE from Noticia  where Id_Noticia =" + noticia.Id_Noticia + ";", conec);

            conec.Open();
            comando.ExecuteNonQuery();//salva e não retorna nennhum valor.
            conec.Close();
        }

    }
}