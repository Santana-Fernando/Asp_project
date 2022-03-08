using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_project.Models
{
    public class Endereco
    {
        [Key]
        public int id_endereco { get; set; }

        [Display(Name = "Logradouro")]
        [Required(ErrorMessage = "Informe o logradouro do seu endereço")]
        public string logradouro { get; set; }

        [Display(Name = "Complemento")]
        public string complemento { get; set; }

        [Display(Name = "CEP")]
        [Required(ErrorMessage = "Obrigatório informar o CEP")]
        public string cep { get; set; }

        [Display(Name = "Número")]
        public string Numero { get; set; }

        [Display(Name = "Cidade")]
        [Required(ErrorMessage = "Obrigatório informar a cidade")]
        public string Cidade { get; set; }

        [Display(Name = "Bairro")]
        [Required(ErrorMessage = "Obrigatório informar o bairro")]
        public string bairro { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Obrigatório informar o estado")]
        public string uf { get; set; }
        
        public Nullable<int> Uid_usuario { get; set; }
        public Usuario U { get; set; }

        public Nullable<int> Lid_loja { get; set; }
        public Loja L { get; set; }
    }
}
