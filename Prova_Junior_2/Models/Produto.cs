using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Prova_Junior_2.Models
{
    public class Produto
    {
        public int Id_Produtos { get; set; }
        public string Nome { get; set; }
        [Required(ErrorMessage = "Preço Campo é obrigatório")]
        public string Preco { get; set; }
        [Required(ErrorMessage = "Descricão Campo é obrigatório")]
        public string Descricao { get; set; }
        public string Marca { get; set; }
        [Required(ErrorMessage = "Modelo Campo é obrigatório")]
        public string Modelo { get; set; }

        public void Cadastrar()

        {
            SqlConnection conec = new SqlConnection("Data Source=.;Initial Catalog=Mvc_Junior;Integrated Security=True");
            SqlCommand comando = new SqlCommand("INSERT INTO Produto VALUES('" + this.Nome + "','" + this.Preco + "','" + this.Descricao + "','" + this.Marca + "','" + this.Modelo + "')", conec);
            conec.Open();
            comando.ExecuteNonQuery();//salva e não retorna nennhum valor.
            conec.Close();
        }
        public static List<Produto> Lista_Produto()
        {
            List<Produto> Lista_produtos = new List<Produto>();
            SqlConnection conec = new SqlConnection("Data Source=.;Initial Catalog=Mvc_Junior;Integrated Security=True");
            SqlCommand comando = new SqlCommand("SELECT * FROM Produto", conec);
            conec.Open();

            Produto produto = new Produto();
            SqlDataReader dr = comando.ExecuteReader();
            while (dr.Read())
            {
                Lista_produtos.Add(new Produto()
                {
                    Id_Produtos = Convert.ToInt32(dr["Id_Produtos"]),
                    Nome = dr["Nome"].ToString(),
                    Preco = dr["Preco"].ToString(),
                    Descricao = dr["Descricao"].ToString(),
                    Marca = dr["Marca"].ToString(),
                    Modelo = dr["Modelo"].ToString(),
                });
            }

            dr.Close();
            return Lista_produtos;
        }
        public List<Produto> Lista_ProdutoID(int id)
        {
            List<Produto> Lista_Produtos = new List<Produto>();
            SqlConnection conec = new SqlConnection("Data Source=.;Initial Catalog=Mvc_Junior;Integrated Security=True");
            SqlCommand comando = new SqlCommand("SELECT * FROM  Produto  where Id_Produtos =" + id + ";", conec);
            conec.Open();

            Produto produto = new Produto();
            SqlDataReader dr = comando.ExecuteReader();
            while (dr.Read())
            {
                Lista_Produtos.Add(new Produto()
                {
                    Id_Produtos = Convert.ToInt32(dr["Id_Produtos"]),
                    Nome = dr["Nome"].ToString(),
                    Preco = dr["Preco"].ToString(),
                    Descricao = dr["Descricao"].ToString(),
                    Marca = dr["Marca"].ToString(),
                    Modelo = dr["Modelo"].ToString(),
                });
            }

            dr.Close();
            return Lista_Produtos;
        }
        public void Alterar_Produto(Produto produto)
        {
            SqlConnection connec = new SqlConnection("Data Source=.;Initial Catalog=Mvc_Junior;Integrated Security=True");
            SqlCommand comando = new SqlCommand("UPDATE Produto SET Nome='" + produto.Nome + "', Preco='" + produto.Preco + "', Descricao='" + produto.Descricao + "', Marca='" + produto.Marca + "', Modelo='" + produto.Modelo + "' WHERE Id_Produtos = " + produto.Id_Produtos + "; ", connec);
            connec.Open();
            comando.ExecuteNonQuery();
            connec.Close();
        }
        public void Excluir(Produto produto)
        {
            SqlConnection conec = new SqlConnection("Data Source=.;Initial Catalog=Mvc_Junior;Integrated Security=True");
            SqlCommand comando = new SqlCommand("DELETE from Produto  where Id_Produtos =" + produto.Id_Produtos + ";", conec);

            conec.Open();
            comando.ExecuteNonQuery();//salva e não retorna nennhum valor.
            conec.Close();
        }
        public static  List<Produto> Lista_Produto_MODELO(string modelo)
        {
            List<Produto> Lista_Produtos = new List<Produto>();
            SqlConnection conec = new SqlConnection("Data Source=.;Initial Catalog=Mvc_Junior;Integrated Security=True");
            SqlCommand comando = new SqlCommand("SELECT * FROM  Produto  where Modelo ='" + modelo + "';", conec);
            conec.Open();

            Produto produto = new Produto();
            SqlDataReader dr = comando.ExecuteReader();
            while (dr.Read())
            {
                Lista_Produtos.Add(new Produto()
                {
                    Id_Produtos = Convert.ToInt32(dr["Id_Produtos"]),
                    Nome = dr["Nome"].ToString(),
                    Preco = dr["Preco"].ToString(),
                    Descricao = dr["Descricao"].ToString(),
                    Marca = dr["Marca"].ToString(),
                    Modelo = dr["Modelo"].ToString(),
                });
            }

            dr.Close();
            return Lista_Produtos;
        }


    }
}
