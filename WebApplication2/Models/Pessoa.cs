using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{
    public class Pessoa
    {
        public int Id_pessoa { get; set; }
        public string Nome { get; set; }
        public int? Idade { get; set; }
        public int? Peso { get; set; }
        //campo não obrigatorio
        //   public int Idade? { get; set; }
        public string Sexo { get; set; }
        public void Cadastrar()

        {
            SqlConnection conec = new SqlConnection("Data Source=.;Initial Catalog=Mvc_Junior;Integrated Security=True");
            SqlCommand comando = new SqlCommand("INSERT INTO Pessoa VALUES('" + this.Nome + "'," + this.Idade + "," + this.Peso + ",'" + this.Sexo + "')", conec);
            conec.Open();
            comando.ExecuteNonQuery();//salva e não retorna nennhum valor.
            conec.Close();
        }

        public DataSet Busca_Pessoa()
        {
            DataSet ds = new DataSet();
            SqlConnection conec = new SqlConnection("Data Source=.;Initial Catalog=Mvc_Junior;Integrated Security=True");
            SqlCommand comando = new SqlCommand("SELECT * FROM Pessoa", conec);
            SqlDataAdapter da = new SqlDataAdapter(comando);
            da.Fill(ds);//percorrer todos registro buscados e joga em ds 
            return ds;
        }
        public  static List<Pessoa> Lista_Pessoas()
        {
            List<Pessoa> Lista_Pessoas = new List<Pessoa>();
            SqlConnection conec = new SqlConnection("Data Source=.;Initial Catalog=Mvc_Junior;Integrated Security=True");
              SqlCommand comando = new SqlCommand("SELECT * FROM Pessoa", conec);
            conec.Open();

            Pessoa aluno = new Pessoa();
            SqlDataReader dr = comando.ExecuteReader();
            while (dr.Read())
            {
                Lista_Pessoas.Add(new Pessoa()
                {
                    Id_pessoa = Convert.ToInt32(dr["Id_pessoa"]),
                    Nome = dr["Nome"].ToString(),
                    Idade =Convert.ToInt32( dr["Idade"].ToString()),
                    Peso = Convert.ToInt32(dr["Peso"].ToString()),
                    Sexo = dr["Sexo"].ToString(),


                });
            }

            dr.Close();
            return Lista_Pessoas;
        }
        public  List<Pessoa> Lista_Pessoas_ID(int pessoa)
        {
            List<Pessoa> Lista_Pessoas = new List<Pessoa>();
            SqlConnection conec = new SqlConnection("Data Source=.;Initial Catalog=Mvc_Junior;Integrated Security=True");
            SqlCommand comando = new SqlCommand("SELECT * FROM  Pessoa  where Id_pessoa =" + pessoa + ";", conec);
            conec.Open();

            Pessoa aluno = new Pessoa();
            SqlDataReader dr = comando.ExecuteReader();
            while (dr.Read())
            {
                Lista_Pessoas.Add(new Pessoa()
                {
                    Id_pessoa = Convert.ToInt32(dr["Id_pessoa"]),
                    Nome = dr["Nome"].ToString(),
                    Idade = Convert.ToInt32(dr["Idade"].ToString()),
                    Peso = Convert.ToInt32(dr["Peso"].ToString()),
                    Sexo = dr["Sexo"].ToString(),


                });
            }

            dr.Close();
            return Lista_Pessoas;
        }
        public void Excluir(Pessoa pessoa)
        {
            SqlConnection conec = new SqlConnection("Data Source=.;Initial Catalog=Mvc_Junior;Integrated Security=True");
            SqlCommand comando = new SqlCommand("DELETE from Pessoa  where Id_pessoa =" + pessoa.Id_pessoa + ";", conec);

            conec.Open();
            comando.ExecuteNonQuery();//salva e não retorna nennhum valor.
            conec.Close();
        }
        public void Alterar(Pessoa pessoa)
        {
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=Mvc_Junior;Integrated Security=True");
            SqlCommand comando = new SqlCommand("UPDATE Pessoa SET Nome='" + pessoa.Nome + "', Idade=" + pessoa.Idade + ", Peso=" + pessoa.Peso + ", Sexo='" + pessoa.Sexo + "' WHERE Id_Pessoa = " + pessoa.Id_pessoa + "; ", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }



    }
}