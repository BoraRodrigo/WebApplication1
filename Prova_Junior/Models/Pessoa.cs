using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prova_Junior.Models
{
    public class Pessoa
    {
        public int Pessoa_Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "Este Campo é obrigatório")]
        public string Cpf { get; set; }


        public int Idade { get; set; }

        [System.Web.Mvc.Remote("validacao_sexo", "Pessoa", ErrorMessage = "Sexo Invalido")]
        public string Sexo { get; set; }


        public static List<Pessoa> Lista_Cadastrar = Retorna_Pessoa_Lista();

        public static List<Pessoa> Retorna_Pessoa_Lista()
        {
            var lista_Pessoa = new List<Pessoa>()
            {
                new Pessoa { Pessoa_Id=1, Nome="Macoratti", Email="macoratti@yahoo.com", Cpf= "11111111111", Idade=5, Sexo="Masculino"},
                new Pessoa { Pessoa_Id=2, Nome="Pedro", Email="pedro@yahoo.com", Cpf= "11111111111", Idade=7, Sexo="Masculino"},
                new Pessoa { Pessoa_Id=3, Nome="Jefferson", Email="jeff@yahoo.com", Cpf= "33333333333", Idade=8, Sexo="Masculino",},
                new Pessoa { Pessoa_Id=4, Nome="Miriam", Email="miriam@yahoo.com", Cpf= "555555", Idade=9, Sexo="Feminino"},              
            };
            return lista_Pessoa;
        }
        public void Excluir(Pessoa pessoa)
        {
            for (int i = 0; Lista_Cadastrar.Count < i; i++)
            {
                if (Lista_Cadastrar[i].Pessoa_Id==pessoa.Pessoa_Id)
                {
                    Lista_Cadastrar.Remove(pessoa);
                }
            }
        }
        public Pessoa retorna_Pessoa(int id)
        {
            Pessoa pessoa = new Pessoa();
            for (int i = 0; i < Lista_Cadastrar.Count; i++)
            {
                if (Lista_Cadastrar[i].Pessoa_Id==id)
                {
                    return Lista_Cadastrar[i];
                }
            }

            return null;
        }
        public void Alterar(Pessoa pessoa)
        {

        }
        
    }
}