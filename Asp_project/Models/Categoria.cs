using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp_project.Models
{
    public class Categoria
    {
        [Key]
        public int id_categoria { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Informe a descrição da categoria")]
        public string descricao { get; set; }

        public Produto Produto { get; set; }
    }
}
