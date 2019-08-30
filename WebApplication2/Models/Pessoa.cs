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
    }



}