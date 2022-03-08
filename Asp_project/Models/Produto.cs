using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_project.Models
{
    public class Produto
    {
        [Key]
        public int id_produto { get; set; }

        public int Lid_loja { get; set; }
        public Loja L { get; set; }

        [Display(Name = "Nome do Produto")]
        [Required(ErrorMessage = "Informe o nome do produto")]
        public string nome_produto { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Informe a descrição do produto")]
        public string descricao_produto { get; set; }

        [Display(Name = "Valor do Produto")]
        [Required(ErrorMessage = "Informe o valor do produto")]
        public decimal valor { get; set; }

        public ICollection<ImagensProdutos> ImagensProdutos { get; set; }

        [Display(Name = "Categoria Produto")]
        [Required(ErrorMessage = "Informe a categoria do produto")]

        public int Cid_categoria { get; set; }
        public Categoria C { get; set; }
    }
}
