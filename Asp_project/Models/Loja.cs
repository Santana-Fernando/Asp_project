using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_project.Models
{
    public class Loja
    {
        [Key]
        public int id_loja { get; set; }

        [Display(Name = "Nome Da Loja")]
        [Required(ErrorMessage = "Obrigatório informar o nome da sua loja")]
        public string nome_loja { get; set; }
            
        [Display(Name = "Descrição Da Loja")]
        public string descicao { get; set; }

        [Display(Name = "CNPJ")]
        [Required(ErrorMessage = "Informe o CNPJ de sua loja")]
        public string cpf_cnpj { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Informe pelo menos um telefone de contato")]
        public string telefone { get; set; }

        [Display(Name = "Celular")]
        public string celular { get; set; }

        [Display(Name = "Funcionamento")]
        [Required(ErrorMessage = "Informe os dias de funciomento da sua loja")]
        public string dias_e_horas_de_funcionamento { get; set; }

        [Display(Name = "Foto")]
        public string fotoLoja { get; set; }

        public int Uid_usuario { get; set; }
        public Usuario U { get; set; }
        public Endereco Endereco { get; set; }

    }
}
