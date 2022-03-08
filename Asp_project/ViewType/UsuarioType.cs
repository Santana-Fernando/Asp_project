using Asp_project.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_project.ViewType
{
    public class UsuarioType
    {
        public int id_usuario { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Obrigatório informar o Nome")]
        public string nome { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Obrigatório informar o um E-mail")]
        public string email { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Obrigatório informar uma senha")]
        public string senha { get; set; }

        [Display(Name = "Confirmação de senha")]
        [Required(ErrorMessage = "confirme a sua senha")]
        public string confirmarSenha { get; set; }

        [Display(Name = "Sobrenome")]
        public string sobrenome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Obrigatório informar o CPF")]
        public string cpf { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Informe pelo menos um telefone de contato")]
        public string telefone { get; set; }

        [Display(Name = "Celular")]
        public string celular { get; set; }

        [Display(Name = "Foto")]
        public string foto { get; set; }
        public Endereco Endereco { get; set; }
        public IFormFile ProfileImage { get; set; }
    }
}
