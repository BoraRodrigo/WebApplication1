using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Prova_Junior.Models
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }

        [Required(ErrorMessage = "Tipo Campo é obrigatório")]

        [System.Web.Mvc.Remote("validacao_tipo", "Usuario", ErrorMessage = "Usuario Deve ser A ou U")]
        public string Tipo { get; set; }

        public string Nome { get; set; }

        [Required(ErrorMessage = "Senha Campo é obrigatório")]
        public string Senha { get; set; }


        public void Cadastrar()

        {
            SqlConnection conec = new SqlConnection("Data Source=.;Initial Catalog=Mvc_Junior;Integrated Security=True");
            SqlCommand comando = new SqlCommand("INSERT INTO UsuarioProva VALUES('" + this.Nome + "','" + this.Tipo + "','" + this.Senha + "')", conec);
            conec.Open();
            comando.ExecuteNonQuery();//salva e não retorna nennhum valor.
            conec.Close();
        }
        public List<Usuario> Lista_Login(string nome, string senha)
        {
            List<Usuario> Lista_Usuario = new List<Usuario>();
            SqlConnection conec = new SqlConnection("Data Source=.;Initial Catalog=Mvc_Junior;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from Usuario where Nome ='" + nome + "' and Senha='" + senha + "';", conec); conec.Open();

            Usuario usuario = new Usuario();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Lista_Usuario.Add(new Usuario()
                {
                    Id_Usuario = Convert.ToInt32(dr["Id_Usuario"]),
                    Nome = dr["Nome"].ToString(),
                    Tipo = dr["Tipo"].ToString(),
                    Senha =dr["Senha"].ToString(),                   
                });
            }
            dr.Close();
            return Lista_Usuario;
        }

    }
}