using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Prova_Junior_2.Models
{
    public class Pessoa
    {
        public int Pessoa_Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Este Campo é obrigatório")]
        public string Cpf { get; set; }
        public string Idade { get; set; }
        public string Sexo { get; set; }

        public void Cadastrar()

        {
            SqlConnection conec = new SqlConnection("Data Source=.;Initial Catalog=Mvc_Junior;Integrated Security=True");
            SqlCommand comando = new SqlCommand("INSERT INTO Pessoa_1 VALUES('" + this.Nome + "','" + this.Email + "','" + this.Cpf + "','" + this.Idade + "','" + this.Sexo + "')", conec);
            conec.Open();
            comando.ExecuteNonQuery();//salva e não retorna nennhum valor.
            conec.Close();
        }
        public static List<Pessoa> Lista_Pessoa()
        {
            List<Pessoa> Lista_noticia = new List<Pessoa>();
            SqlConnection conec = new SqlConnection("Data Source=.;Initial Catalog=Mvc_Junior;Integrated Security=True");
            SqlCommand comando = new SqlCommand("SELECT * FROM Pessoa_1", conec);
            conec.Open();

            Pessoa pessoa = new Pessoa();
            SqlDataReader dr = comando.ExecuteReader();
            while (dr.Read())
            {
                Lista_noticia.Add(new Pessoa()
                {
                    Pessoa_Id = Convert.ToInt32(dr["Id_Pessoa"]),
                    Nome = dr["Nome"].ToString(),
                    Email = dr["Email"].ToString(),
                    Cpf = dr["Cpf"].ToString(),
                    Idade = dr["Idade"].ToString(),
                    Sexo = dr["Sexo"].ToString(),
                });
            }

            dr.Close();
            return Lista_noticia;
        }
        public List<Pessoa> Lista_NoticiaID(int id)
        {
            List<Pessoa> Lista_Pessoa = new List<Pessoa>();
            SqlConnection conec = new SqlConnection("Data Source=.;Initial Catalog=Mvc_Junior;Integrated Security=True");
            SqlCommand comando = new SqlCommand("SELECT * FROM  Pessoa_1  where Id_Pessoa =" + id + ";", conec);
            conec.Open();

            Pessoa Pessoa = new Pessoa();
            SqlDataReader dr = comando.ExecuteReader();
            while (dr.Read())
            {
                Lista_Pessoa.Add(new Pessoa()
                {
                    Pessoa_Id = Convert.ToInt32(dr["Id_Pessoa"]),
                    Nome = dr["Nome"].ToString(),
                    Email = dr["Email"].ToString(),
                    Cpf = dr["Cpf"].ToString(),
                    Idade = dr["Idade"].ToString(),
                    Sexo = dr["Sexo"].ToString(),
                });
            }

            dr.Close();
            return Lista_Pessoa;
        }
        public void Alterar_Pessoa(Pessoa pessoa)
        {
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=Mvc_Junior;Integrated Security=True");
            SqlCommand comando = new SqlCommand("UPDATE Pessoa_1 SET Nome='" + pessoa.Nome + "', Email='" + pessoa.Email + "', Cpf='" + pessoa.Cpf + "', Sexo='" + pessoa.Sexo + "', Idade='" + pessoa.Idade + "' WHERE Id_Pessoa = " + pessoa.Pessoa_Id + "; ", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }
        public void Excluir(Pessoa pessoa)
        {
            SqlConnection conec = new SqlConnection("Data Source=.;Initial Catalog=Mvc_Junior;Integrated Security=True");
            SqlCommand comando = new SqlCommand("DELETE from Pessoa_1  where Id_Pessoa =" + pessoa.Pessoa_Id + ";", conec);

            conec.Open();
            comando.ExecuteNonQuery();//salva e não retorna nennhum valor.
            conec.Close();
        }
    }
}

