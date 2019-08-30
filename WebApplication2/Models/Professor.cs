using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Professor
    {
        [Required(ErrorMessage ="Este Campo é obrigatório")]
        public String Nome { get; set; }


        [StringLength(10,MinimumLength =3,ErrorMessage ="O sobrenome deve ter mais de 10 digitos")]
        public string Sobrenome { get; set; }



        [Range(18,50, ErrorMessage ="A idade não pode ser inserida")]
        public int Idade { get; set; }

        public string Senha { get; set; }

        [Compare("Senha",ErrorMessage ="Senha não confere")]
        public string Confirma_Senha { get; set; }


        [System.Web.Mvc.Remote("validacao","Professor",ErrorMessage ="Sexo invalido")]
        public string Sexo { get; set; }


        public string Email { get; set; }

        //vlidar 2 campos
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O cpf deve ter 11 digitos")]
        [System.Web.Mvc.Remote("validacao_cpf", "Professor",AdditionalFields ="Email", ErrorMessage = "Cpf Cadastrado")]
        public string Cpf { get; set; }

        //[StringLength(11, MinimumLength = 11, ErrorMessage = "O cpf deve ter 11 digitos")]
        //[System.Web.Mvc.Remote("validacao_cpf", "Professor", ErrorMessage = "Cpf Cadastrado")]
        //public string Cpf { get; set; }
    }
}